            var response = new HttpResponseMessage(HttpStatusCode.OK);
                using (var responseApi = (HttpWebResponse)request.GetResponse())
                {                    
                    using (var reader = new StreamReader(responseApi.GetResponseStream()))
                    {
                        var objText = reader.ReadToEnd();
                        response.Content = new StringContent(objText, Encoding.UTF8, "application/json");
                    }
                }
                return response;
