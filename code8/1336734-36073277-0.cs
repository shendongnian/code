     TCPClient client = new TCPClient("some ip", 1234);
     using( var str = client.GetStream())
     {
        using(var i = new CryptoStream(str, myEncryptor(),  CryptoStreamMode.Write)             {
          i.Write(some Data, 0, 1024);
      }
       using (var o = new CryptoStream(str, myEncryptor, CryptoStreamMode.Read)
       {
           var x = o.Read();
      }
     }
