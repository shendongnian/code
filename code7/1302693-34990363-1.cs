      private string ProcessRestMethod(string methodName, string parameters)
      {
            string result = "";
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string strParams = parameters;
                if ((!String.IsNullOrEmpty(parameters)) && (parameters.IndexOf('?') != 0))
                    strParams = "?" + parameters;
                var task = httpClient.GetStringAsync(baseUri + methodName + strParams);
                // Just call `task.Result` here :)
                result = task.Result;
            }
            if (result == "")
                result = "{\"status\":{\"code\":1000,\"message\":\"Unkown Error Ocured\"}}";
            return result;
        }
