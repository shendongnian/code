                w.Headers.Add(HttpRequestHeader.Authorization, token_type + " " + access_token);
                string str = w.DownloadString(URL);
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(FlightObject));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(str)))
                {
                    f = (FlightObject)serializer.ReadObject(ms);
                }
            }`**
