    //the plan here is to make a model that holds your currIndex and byte array so you can return that model from a task
    public class MyModel 
    {
        public CurrentIndex CurrIndex {get;set;} //not sure what type CurrentIndex is, int?
        public byte[] FileBytes {get;set;}
    }
        
    foreach (var currIndexGroup in blobsGroupedByIndex)
    {
        
        var myTasks = new List<Task<MyModel>>();
        foreach (var currIndex in currIndexGroup)
        {     
            myTasks.Add(Task<MyModel>.Factory.StartNew(async () => 
            {
                var myModel = new MyModel();
                myModel.CurrIndex = currIndex;
  
                long fileByteLength = myModel.CurrIndex.Properties.Length;
                myModel.FileBytes = new byte[fileByteLength];
                await currIndex.DownloadToByteArrayAsync(myModel.FileBytes, 0);
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
