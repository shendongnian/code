    try
    {
       if(File.Exists("E:\\test.txt") && File.GetLastWriteTime(path).Day = DateTime.Now.Day)
       {
         File.WriteAllText("E:\\test.txt", "welcome");     
       } 
       else
       { 
                   //code for next day
       }
    }
    catch (Exception ex)
    {
      Response.Write(ex.Message);
    }
