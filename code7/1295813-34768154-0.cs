    client.UploadStringCompleted += new UploadStringCompletedEventHandler(delegate(object sender, UploadStringCompletedEventArgs e)
    {
        Console.WriteLine(GetFedAuthCookieFromSOAPResponse(e.Result));
        Console.WriteLine("Press ENTER to close program");
        Console.ReadLine();
    });
