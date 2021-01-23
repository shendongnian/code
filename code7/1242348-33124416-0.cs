    public static void save(System system, String filePath) 
    {
        //Make filestream
        using(FileStream fs = new FileStream(filePath, FileMode.Create))    
        {
            //Serialize offerte
            BinaryFormatter bf = new BinaryFormatter();
            
            using (DeflateStream cs = new DeflateStream(fs, CompressionMode.Compress)) {
    
               bf.Serialize(cs, system);
    
               //Push through
               fs.Flush();
               cs.Flush();
               cs.Close();
           }
        }     
    }
