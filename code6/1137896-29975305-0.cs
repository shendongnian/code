    IList<FolderDetails> ListToCheck;
    
     using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\LogFile.txt"))
     {
         foreach (string line in ListToCheck)
         {                       
             file.WriteLine(line);                        
         }
    }
