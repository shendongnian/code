    public static void UploadFile(string url, string filePath, string Header)
        {
            using (var client = new WebClient())
            {
                if (!string.IsNullOrEmpty(Header))
                {
                    client.Headers.Add("Authorization", Header);
                }
                byte[] result = client.UploadFile(url, filePath);
                string responseAsString = Encoding.Default.GetString(result);
            }
        } 
