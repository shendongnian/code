    private String SendCommand(String command)
        {
            String response = null;
                 
            using (WebClient client = new WebClient())
            {
                client.Proxy = null;
                response = client.DownloadString(command);
            }
            return response;
        }
