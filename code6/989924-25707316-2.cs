            // GET customer with id 1
            var client = new RestClient(PrestaShopBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(PrestaShopAccount, "");
            RestRequest request = new RestRequest("/customers/1", Method.GET);
            IRestResponse response = client.Execute(request);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content);
            doc.Save(@"Customer.xml");
            // do something with customer file
            
            // init XMLDocument and load customer in it
            doc = new XmlDocument();
            doc.Load(@"Customer.xml");
            // Update (PUT) customer
            request = new RestRequest("/customers/1", Method.PUT);
            request.Parameters.Clear();
            request.AddParameter("text/xml;charset=utf-8", doc.InnerXml, ParameterType.RequestBody);
            response = client.Execute(request);
