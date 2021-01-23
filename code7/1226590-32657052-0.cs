    var res = new byte[1000];
    webRequest.GetResponse().GetResponseStream().Read(res, 0, 1000);
    
    Console.WriteLine(ASCIIEncoding.ASCII.GetString(res));
    Console.ReadKey();
