      public async Task<byte[]> Download(string url)
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] fileArray = await client.GetByteArrayAsync(url);
                    return fileArray;
                }
                
            }
