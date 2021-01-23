     using (WebClient client = new WebClient())
     {
          client.Encoding = Encoding.UTF8;
          client.Encoding = UTF8Encoding.UTF8;
          string htmlCode = client.DownloadString("http://www.feleziran.ir/products/milgerd");
          System.IO.File.WriteAllText("c:\\htmlfile.html", htmlCode);
                   
     }
