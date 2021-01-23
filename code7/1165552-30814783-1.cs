     ...
     bool valid = false;
     using (WebClient client = new WebClient())
     {
         using (Stream stream = client.OpenRead("http://haha.com/access.txt"))
         {
             using (StreamReader reader = new StreamReader(stream))
             {
                 string line;
                 while ((line = reader.ReadLine()) != null)
                 {
                     if (line.Equals(input))
                     {
                         valid = true;
                         break;
                     }
                 }
             }
         }
     }
     if (valid)
     {
         // password is correct
         ...
     }
     else
     {
        MessageBox.Show("This software has been deactivated because of wrong pass", "YOUR ACCESS HAS BEEN LIMITED");
        appexit();
     }
     ...
