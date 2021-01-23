    int retries = 3;    
    while(retries = 0)
    {
       if(tryWriteFile())
       {
          break;
       } 
       retries--;
       if(retries < 1)
       {
          //log that we failed to write the file.
       }
    }
     
    protected void tryWriteFile()
    {
       try
       {
         //open and obtain read/write lock on the file
         using (var fs = File.Open(fileLoc, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
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
