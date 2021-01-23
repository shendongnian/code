    //the plan here is to make a model that holds your currIndex and byte array so you can return that model from a task
    public class MyModel 
    {
        public CloudBlockBlob CurrIndex {get;set;} 
        public byte[] FileBytes {get;set;}
    }
        
    foreach (var currIndexGroup in blobsGroupedByIndex)
    {
        
        var myTasks = new List<Task<MyModel>>();
        foreach (var currIndex in currIndexGroup)
        {     
            myTasks.Add(Task<MyModel>.Factory.StartNew(() => 
            {
                var myModel = new MyModel();
                myModel.CurrIndex = currIndex;
  
                long fileByteLength = myModel.CurrIndex.Properties.Length;
                myModel.FileBytes = new byte[fileByteLength];
                currIndex.DownloadToByteArray(myModel.FileBytes, 0);
                return myModel;
            });
        }
        Task.WaitAll(myTasks);
        
        foreach (var task in myTasks)
        {
            MyModel myModel = task.Result;
            DataRow dr = dtResult.NewRow();
            dr[myModel.CurrIndex.Metadata["columnName"]] = DeflateStream.UncompressString(myModel.FileBytes);
            dtResult.Rows.Add(dr);
        }
    }
