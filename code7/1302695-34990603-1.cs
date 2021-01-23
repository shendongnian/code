        private async Task<string> ProcessRestMethod(string methodName, string parameters)
        {
            string result = "";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string strParams = parameters;
                if ((!String.IsNullOrEmpty(parameters)) && (parameters.IndexOf('?') != 0))
                    strParams = "?" + parameters;
                result = await httpClient.GetStringAsync(baseUri + methodName + strParams);
                
            }
            if (result == "")
                result = "{\"status\":{\"code\":1000,\"message\":\"Unkown Error Ocured\"}}";
            return result;
        }
