    public static void SendRequest(string url)
    {
        var thread = new Thread(ThisClass.SendRequest));
        thread.Start(url);
        // maybe do something to monitor the thread object?
    }
    private static void SendRequest(object url)
    {
        var response = ((HttpWebRequest)WebRequest.Create(string.Format("{0}", url))).GetResponse();
        // You have a response, might as well examine it for success/failure
    }
