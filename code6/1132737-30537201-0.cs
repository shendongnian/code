        private void sendFilesViaFTP(List<string> fileNames){
            WebClient client = new WebClient();
            client.Credentials = new NetworkCredential("username", "password");
            foreach(string each in fileNames){
                byte[] response = client.UploadFile("ftp://endpoint/" + each, "STOR", each);
                string result = System.Text.Encoding.ASCII.GetString(response);
                Console.Write(result);
            }
        }
