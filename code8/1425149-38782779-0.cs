    string source = "Sample string with more than 8000 Characters";
    using (MD5 md5Hash = MD5.Create()) 
    { 
        Console.WriteLine(GetMd5Hash(md5Hash, source, System.Text.Encoding.ASCII)); <br/>Console.WriteLine(GetMd5Hash(md5Hash, source, System.Text.Encoding.UTF7));
        Console.WriteLine(GetMd5Hash(md5Hash, source, System.Text.Encoding.UTF8));  
        Console.WriteLine(GetMd5Hash(md5Hash, source,System.Text.Encoding.Unicode)); 
        Console.WriteLine(GetMd5Hash(md5Hash, source, System.Text.Encoding.UTF32)); 
    }
