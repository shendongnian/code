     // make sure here all Ole Automation servers (like Excel or Word)
     // have closed the file (so close the workbook, document etc)
     // we iterate a couple of times (10 in this case)
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
