    public static bool SocketConnect(string host, int port)
    {
        var is_success = false;
        try
        {
             var connsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
             connsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 200);
             Thread.Sleep(500);
             var hip = IPAddress.Parse(host);
             var ipep = new IPEndPoint(hip, port);
             connsock.Connect(ipep);
             if (connsock.Connected)
             {
                 is_success = true;
             }
             connsock.Close();
         }
         catch (SocketException)
         {
             is_success = false;
         }
         catch (Exception)
         {
             is_success = false;
         }
         return is_success;
    }
    private static string GetResponseText(HttpWebResponse response, out string error)
    {
         error = string.Empty;
         if (response == null)
         {
             error = "Listed proxy servers did not responding.";
             return null;
         }
         var responseFromServer = string.Empty;
         var responceStream = response.GetResponseStream();
         if (responceStream != null)
         {
             using (var reader = new StreamReader(responceStream))
             {
                 responseFromServer = reader.ReadToEnd();
             }
         }
         return responseFromServer;
    }
