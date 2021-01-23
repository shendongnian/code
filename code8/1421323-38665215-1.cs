            public byte[] GetEncryptedStream(string jsonData)
            {
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(jsonData);
                byte[] key = null;//GetKey() //I am assuming you arealy have your Key
                //Call your encrypt function below
                byte[] encryptedDataBytes = encrypt(dataBytes, key); // I am assuming your function returns byte array 
                return encryptedDataBytes;
            }
    
            public HttpResponseMessage GetHttpResponseMessage()
            {
                var result = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
                String jsonString = "your json data";
                byte[] data = GetEncryptedStream(jsonString);
                result.Content = new ByteArrayContent(data);
                return result;
            }
