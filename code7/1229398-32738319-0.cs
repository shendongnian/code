     for(int i=0; i< 10; i++) 
     {
         try 
         {
            System.IO.File.Delete(path);
            break;
         } catch (Exception exc) 
         {
             Trace.WriteLine("failed delete {0}", exc.Message);
         }
     }
