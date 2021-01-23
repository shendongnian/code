       HttpResponseMessage response;
        public async Task<string> webserviceResponse(string HttpMethod)
        {      
            // check internet connection is available or not   
 
            if (NetworkInterface.GetIsNetworkAvailable() == true)
            {
               // CancellationTokenSource cts = new CancellationTokenSource(2000); // 2 seconds
                HttpClient client = new HttpClient();
                MultipartFormDataContent mfdc = new MultipartFormDataContent();
                mfdc.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
                string GenrateUrl = "your url";
                if (HttpMethod == "POST")
                {
                    response = await client.PostAsync(GenrateUrl, mfdc);
                }
                else if (HttpMethod == "PUT")
                {
                    response = await client.PutAsync(GenrateUrl, mfdc);
                }
                else if (HttpMethod == "GET")
                {
                    response = await client.GetAsync(GenrateUrl);
                }
                var respon = await response.Content.ReadAsStringAsync();
                string convert_response = respon.ToString();
                return convert_response;
            }
            else
            {
                return "0";
            }
        }
