    /// <summary>
        /// Submit post request with an arbitrary input model and an arbitrary output model (could be the same model).
        /// URL's of format baseURL/controller/action a la .NET MVC web api, i.e., http://something.com/api/Product/Sales
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="controller"></param>
        /// <param name="action"></param>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        private U DoWebAPIPostRequest<T, U>(string controller, string action, T inputModel)
        {
            string baseURL = "http://localhost:1234/api"; //add your base url for your service here
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                string url = baseURL + "api/" + controller + "/" + action;
                var response = client.PostAsJsonAsync<T>(url, inputModel);
                string error = response.Result.Content.ReadAsStringAsync().Result;
                if (response.Result.IsSuccessStatusCode)
                {
                    U result = response.Result.Content.ReadAsAsync<U>().Result;
                    return result;
                }
                else throw new Exception(error);
            }
        }
