    public async Task<double> getRate(string from, string to)
            {
                string xml = string.Empty;
                Uri url = new Uri("http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency="+from+"&ToCurrency="+to);
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                var response = await httpClient.GetAsync(url);
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                using (var streamReader = new StreamReader(responseStream))
                {
                   xml = streamReader.ReadToEnd();
                }
                XDocument xDoc = XDocument.Parse(xml);
                XNamespace xmlns = "http://www.webserviceX.NET/";
                string value = (string)xDoc.Element(xmlns + "double");
                return System.Convert.ToDouble(value);
            }
