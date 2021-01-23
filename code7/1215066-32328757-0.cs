                String File = "File.txt";
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(File);
    
               if(fileinfo.Exists)
               {
                   using (System.IO.FileStream file = new System.IO.FileStream(File, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite))
                 {
                     // operation on file here
                 }
               }else
               {
                   using (System.IO.FileStream file = new System.IO.FileStream(File, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite))
                   {
                       // operation on file here now the file is new file 
                   }
               } 
