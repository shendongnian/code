    bool done;
    while(true)
    {
        if(condition == true)
        {
            if(File.Exists(filename))
            {
               using (System.Net.WebClient client = new System.Net.WebClient())
               {
                 client.Credentials = new System.Net.NetworkCredential("username", "password");
                 int count = 0;
                 done = false;
                 while (count < 4)
                 {
                    try
                    {
                        client.UploadFile(ftpServer  + new FileInfo(filename).Name, "STOR", filename);
                       count = 4;
                       done = true;
                    }
                    catch(Exception ex)
                    {
                        System.Threading.Thread.Sleep(5000);
                        count++;
                    }
                  }
                  if (!done)
                  {
                     //handle the error
                  }
               }
               File.Delete(filename);
           }
        }
    }
