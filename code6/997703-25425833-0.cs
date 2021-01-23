    class MyFileWriter{
        Public static void MergeandWrite(params List<string> list){
             var hugeStringBuilder = new StringBuilder();
             foreach(var singleList : list){
                 foreach(var singleItem : singleList){
                     hugeStringBuilder.append(singleItem);
                 }
             }
        }
        
       File.WriteAllText("path/to/somewhere.csv",hugeStringBuilder.ToString())
    }
