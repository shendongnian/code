            `
            var client = new RestClient(PrestaShopBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(PrestaShopAccount, "");
            RestRequest request = new RestRequest("/employees/{id}", Method.GET);
            request.AddUrlSegment("id", "5");
            IRestResponse response = client.Execute(request);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content);
            XmlNode node2Remove = doc.SelectSingleNode("/prestashop/employee/stats_compare_from");
            node2Remove.ParentNode.RemoveChild(node2Remove);
            node2Remove = doc.SelectSingleNode("/prestashop/employee/stats_compare_to");
            node2Remove.ParentNode.RemoveChild(node2Remove);
            // Update
            request = new RestRequest("/employees/{id}", Method.PUT);
            request.AddUrlSegment("id", "5");
            request.AddHeader("Accept", "text/xml");
            request.Parameters.Clear();
            request.AddParameter("text/xml;charset=utf-8", doc.InnerXml, ParameterType.RequestBody);
            response = client.Execute(request);`
