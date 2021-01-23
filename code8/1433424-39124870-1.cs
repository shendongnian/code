     private async void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            await AddNumbersAsync(new Uri("http://xxxxxx/TestService.asmx"), "txt1", "txt2", "txt3");
        }
        public async Task<int> AddNumbersAsync(Uri uri, string t1, string t2, string t3)
        {
            var soapString = this.ConstructSoapRequest(t1, t2, t3);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("SOAPAction", "http://TestServiceService/ITestServiceService/Save");
                var content = new HttpStringContent(soapString, Windows.Storage.Streams.UnicodeEncoding.Utf8, "text/xml");
                using (var response = await client.PostAsync(uri, content))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    return this.ParseSoapResponse(soapResponse);
                }
            }
        }
        private string ConstructSoapRequest(string t1, string t2, string t3)
        {
            return String.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
    <s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"">
        <s:Body>
            <Save xmlns=""http://TestService/"">
                <textbox>{0}</textbox>
                <textbox>{1}</textbox>
                <textbox>{2}</textbox>
            </Save>
        </s:Body>
    </s:Envelope>", t1, t2, t3);
        }
        private int ParseSoapResponse(string response)
        {//Custom this function based on your SOAP response 
            var soap = XDocument.Parse(response);
            XNamespace ns = "http://TestService/";
            var result = soap.Descendants(ns + "SaveResponse").First().Element(ns + "SaveResult").Value;
            return Int32.Parse(result);
        }
