    void WriteToNetworkFile()
    {
      int retries = 3;    
      while(retries > 0)
      {
         if(tryWriteFile())
         {
            break;
         } 
         retries--;
         // you could add a timeout here to make sure your attempts are a little more
         //spaced out.
         //it could be in the form of a Thread.Sleep, or you could extract a method and
         //call it using a timer.
         if(retries < 1)
         {
            //log that we failed to write the file and gave up on trying.
         }
      }
    }    
    protected void tryWriteFile()
    {
       try
       {
         //you could pass this path as a parameter too.
         var fileLoc = "\\server\folder\file.ext";
         //open and obtain read/write lock on the file
         //using FileMode.CreateNew will ensure that a new file is created.
         //alternatively, you can use FileMosw.Create to create a new file
         //or overwrite the old file if it is there.
         using (var fs = File.Open(fileLoc, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None))
         {
              var sw = new StreamWriter(fs);
              sw.Write("file contents go here");
              sw.Flush();
              sw.Close();
              return true;
         }
        }
        catch(Exception e)
        {
           //you might want to log why the write failed here.
           return false;
        }
    }
