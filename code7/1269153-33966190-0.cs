            public byte[] GetWebRequest()
            {
               var client = new RestClient("http://dl.test.net/test.zip");
               var request = new RestRequest(Method.GET);
               IRestResponse response = client.Execute(request);
               var BytesOfFile = response.RawBytes;
               return BytesOfFile;
            }
           
