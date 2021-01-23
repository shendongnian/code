    public static void PostString (string address)
    {
        string method = "POST";
        WebClient client = new WebClient ();
        string reply = client.UploadString (address + param1, method, json);
    
        Console.WriteLine (reply);
    }
