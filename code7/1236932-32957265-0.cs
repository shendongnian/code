    public static void WriteDataListToFile<T>(T dataList, string folderPath, string fileName) where T : IEnumerable, ICollection
     {    
         //Check to see if file already exists
         if(!File.Exists(folderPath + fileName))
         {
             //if not, create it
             File.Create(folderPath + fileName);
         }
         using(StreamWriter sw = new StreamWriter(folderPath + fileName))   
         {
            // added Cast<T>
             foreach(T type in dataList.Cast<T>())
             {
                 sw.WriteLine(type.ToString());
             }
         }
    } 
