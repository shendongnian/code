    class UriTemplateDispatchFormatter : IDispatchMessageFormatter
    {
        internal Dictionary<int, string> pathMapping;
        internal Dictionary<int, KeyValuePair<string, Type>> queryMapping;
        Uri baseAddress;
        IDispatchMessageFormatter bodyFormatter;
        string operationName;
        QueryStringConverter qsc;
        int totalNumUTVars;
        UriTemplate uriTemplate;
        public UriTemplateDispatchFormatter(OperationDescription operationDescription, IDispatchMessageFormatter bodyFormatter, QueryStringConverter qsc, string contractName, Uri baseAddress)
        {
            this.bodyFormatter = bodyFormatter;
            this.qsc = qsc;
            this.baseAddress = baseAddress;
            this.operationName = operationDescription.Name;
            Populate(
                out this.pathMapping,
                out this.queryMapping,
                out this.totalNumUTVars,
                out this.uriTemplate,
                operationDescription,
                qsc,
                contractName);
        }
        public void DeserializeRequest(Message message, object[] parameters)
        {
            object[] bodyParameters = new object[parameters.Length - this.totalNumUTVars];
            if (bodyParameters.Length != 0)
            {
                this.bodyFormatter.DeserializeRequest(message, bodyParameters);
            }
            int j = 0;
            UriTemplateMatch utmr = null;
            string UTMRName = "UriTemplateMatchResults";
            if (message.Properties.ContainsKey(UTMRName))
            {
                utmr = message.Properties[UTMRName] as UriTemplateMatch;
            }
            else
            {
                if (message.Headers.To != null && message.Headers.To.IsAbsoluteUri)
                {
                    utmr = this.uriTemplate.Match(this.baseAddress, message.Headers.To);
                }
            }
            NameValueCollection nvc = (utmr == null) ? new NameValueCollection() : utmr.BoundVariables;
            for (int i = 0; i < parameters.Length; ++i)
            {
                if (this.pathMapping.ContainsKey(i) && utmr != null)
                {
                    parameters[i] = nvc[this.pathMapping[i]];
                }
                else if (this.queryMapping.ContainsKey(i) && utmr != null)
                {
                    string queryVal = nvc[this.queryMapping[i].Key];
                    parameters[i] = this.qsc.ConvertStringToValue(queryVal, this.queryMapping[i].Value);
                }
                else
                {
                    parameters[i] = bodyParameters[j];
                    ++j;
                }
            }
        }
        public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
        {
            throw new NotImplementedException();
        }
        private static void Populate(out Dictionary<int, string> pathMapping,
        out Dictionary<int, KeyValuePair<string, Type>> queryMapping,
        out int totalNumUTVars,
        out UriTemplate uriTemplate,
        OperationDescription operationDescription,
        QueryStringConverter qsc,
        string contractName)
        {
            pathMapping = new Dictionary<int, string>();
            queryMapping = new Dictionary<int, KeyValuePair<string, Type>>();
            string utString = GetUTStringOrDefault(operationDescription);
            uriTemplate = new UriTemplate(utString);
            List<string> neededPathVars = new List<string>(uriTemplate.PathSegmentVariableNames);
            List<string> neededQueryVars = new List<string>(uriTemplate.QueryValueVariableNames);
            Dictionary<string, byte> alreadyGotVars = new Dictionary<string, byte>(StringComparer.OrdinalIgnoreCase);
            totalNumUTVars = neededPathVars.Count + neededQueryVars.Count;
            for (int i = 0; i < operationDescription.Messages[0].Body.Parts.Count; ++i)
            {
                MessagePartDescription mpd = operationDescription.Messages[0].Body.Parts[i];
                string parameterName = XmlConvert.DecodeName(mpd.Name);
                if (alreadyGotVars.ContainsKey(parameterName))
                {
                    throw new InvalidOperationException();
                }
                List<string> neededPathCopy = new List<string>(neededPathVars);
                foreach (string pathVar in neededPathCopy)
                {
                    if (string.Compare(parameterName, pathVar, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (mpd.Type != typeof(string))
                        {
                            throw new InvalidOperationException();
                        }
                        pathMapping.Add(i, parameterName);
                        alreadyGotVars.Add(parameterName, 0);
                        neededPathVars.Remove(pathVar);
                    }
                }
                List<string> neededQueryCopy = new List<string>(neededQueryVars);
                foreach (string queryVar in neededQueryCopy)
                {
                    if (string.Compare(parameterName, queryVar, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (!qsc.CanConvert(mpd.Type))
                        {
                            throw new InvalidOperationException();
                        }
                        queryMapping.Add(i, new KeyValuePair<string, Type>(parameterName, mpd.Type));
                        alreadyGotVars.Add(parameterName, 0);
                        neededQueryVars.Remove(queryVar);
                    }
                }
            }
            if (neededPathVars.Count != 0)
            {
                throw new InvalidOperationException();
            }
            if (neededQueryVars.Count != 0)
            {
                throw new InvalidOperationException();
            }
        }
        private static string GetUTStringOrDefault(OperationDescription operationDescription)
        {
            string utString = GetWebUriTemplate(operationDescription);
            if (utString == null && GetWebMethod(operationDescription) == "GET")
            {
                utString = MakeDefaultGetUTString(operationDescription);
            }
            if (utString == null)
            {
                utString = operationDescription.Name;
            }
            return utString;
        }
        private static string MakeDefaultGetUTString(OperationDescription od)
        {
            StringBuilder sb = new StringBuilder(XmlConvert.DecodeName(od.Name));
            //sb.Append("/*"); // note: not + "/*", see 8988 and 9653
            if (!IsUntypedMessage(od.Messages[0]))
            {
                sb.Append("?");
                foreach (MessagePartDescription mpd in od.Messages[0].Body.Parts)
                {
                    string parameterName = XmlConvert.DecodeName(mpd.Name);
                    sb.Append(parameterName);
                    sb.Append("={");
                    sb.Append(parameterName);
                    sb.Append("}&");
                }
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }
        private static bool IsUntypedMessage(MessageDescription message)
        {
            if (message == null)
            {
                return false;
            }
            return (message.Body.ReturnValue != null && message.Body.Parts.Count == 0 && message.Body.ReturnValue.Type == typeof(Message)) ||
                (message.Body.ReturnValue == null && message.Body.Parts.Count == 1 && message.Body.Parts[0].Type == typeof(Message));
        }
        private static void EnsureOk(WebGetAttribute wga, WebInvokeAttribute wia, OperationDescription od)
        {
            if (wga != null && wia != null)
            {
                throw new InvalidOperationException();
            }
        }
        private static string GetWebUriTemplate(OperationDescription od)
        {
            // return exactly what is on the attribute
            WebGetAttribute wga = od.Behaviors.Find<WebGetAttribute>();
            WebInvokeAttribute wia = od.Behaviors.Find<WebInvokeAttribute>();
            EnsureOk(wga, wia, od);
            if (wga != null)
            {
                return wga.UriTemplate;
            }
            else if (wia != null)
            {
                return wia.UriTemplate;
            }
            else
            {
                return null;
            }
        }
        private static string GetWebMethod(OperationDescription od)
        {
            WebGetAttribute wga = od.Behaviors.Find<WebGetAttribute>();
            WebInvokeAttribute wia = od.Behaviors.Find<WebInvokeAttribute>();
            EnsureOk(wga, wia, od);
            if (wga != null)
            {
                return "GET";
            }
            else if (wia != null)
            {
                return wia.Method ?? "POST";
            }
            else
            {
                return "POST";
            }
        }
    }
