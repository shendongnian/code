        private byte[] DownloadMediaMethod(string mediaId)
        {
            var cert = new X509Certificate2("Keystore/p12_keystore.p12", "p12_keystore_password");
            var handler = new WebRequestHandler { ClientCertificates = { cert } };
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Custom_Header_If_You_Need", "Value_For_Custom_Header");
                var httpResponse = client.GetAsync(new Uri($"https://my_api.my_company.com/api/v1/my_media_controller/{mediaId}")).Result;
                //Below one line is most relevant to this question, and will address your problem.  Other code in this example if just to show the solution as a whole.
                var result = httpResponse.Content.ReadAsByteArrayAsync().Result;
                try
                {
                    httpResponse.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    if (result == null || result.Length == 0) throw;
                    using (var ms = new MemoryStream(result))
                    {
                        var sr = new StreamReader(ms);
                        throw new Exception(sr.ReadToEnd(), ex);
                    }
                }
                return result;
            }
        }
