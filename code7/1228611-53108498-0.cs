        public Customer GetCustomerDetailsByCustomerId(int id)
        {
            var client = new RestClient("http://localhost:3000/Api/GetCustomerDetailsByCustomerId/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-Token-Key", "dsds-sdsdsds-swrwerfd-dfdfd");
            IRestResponse response = client.Execute(request);
            var content = response.Content; // raw content as string
            dynamic json = JsonConvert.DeserializeObject(content);
            JObject customerObjJson = jsonData.CustomerObj;
            var customerObj = customerObjJson.ToObject<Customer>();
            return customerObj;
        }
