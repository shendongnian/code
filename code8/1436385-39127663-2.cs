    try
    {
       if(!File.Exists("E:\\test.txt") )
       {
         File.WriteAllText("E:\\test.txt", "welcome");     
       } 
       else
       { 
           if(File.GetLastWriteTime(path).Day != DateTime.Now.Day)   
           {
             //code for next day
           }  
       }
    }
    catch (Exception ex)
    {
      Response.Write(ex.Message);
    }
