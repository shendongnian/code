     IEnumerable<DataTable> GetFileData(string sourceFileFullName)
        {            
           
            int chunkRowCount = 0;
         
            using (var sr = new StreamReader(sourceFileFullName))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {                                                  
                   chunkRowCount++;
                   var chunkDataTable = ; ////Code for filling datatable or whatever   
    
                    if (chunkRowCount == 10000)
                    {
                        chunkRowCount = 0;
                        yield return chunkDataTable;
                        chunkDataTable = null;
                    }
                }
            }
            //return last set of data which less then chunk size
            if (null != chunkDataTable)                           
                yield return chunkDataTable;            
        }
