    Start()
    {
        try
        {
            using (WebClient client = new WebClient())
            {
                using (Stream stream = client.OpenRead("http://myserver.com"))
                {
                    Debug.Log("Connected to server");
                    InitiateLoad();
                }
             }
         }
         catch
         {
             Debug.Log("Failed to connect to server");
         }
    }
