       private static long GetNextCRLFPosition(FileStream stream) {
         try {
           long savedPosition = fs.Position;
    
           for (int item = fs.ReadByte(); item >= 0; item = fs.ReadByte()) {
             if (item == '\r') {
               item = fs.ReadByte();
     
               if (item == '\n') 
                 return fs.Position - 2;
               else 
                 fs.Seek(-1, SeekOrigin.Current); 
             }
           }     
           return -1; 
         }
         finally {
           fs.Seek(savedPosition, SeekOrigin.Begin);
         }
       }
    
       ...  
    
       using (FileStream fs = new FileStream(@"C:\MyFile.Text", FileMode.Open)) {
         ...
         // The next "\r\n" is in shift bytes
         long shift = GetNextCRLFPosition(fs);     
         ...
       }
