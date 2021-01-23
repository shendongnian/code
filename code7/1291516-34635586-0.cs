    private void ComputeBackgroundAdjudicationTask(long taskId, Action<int> completedAdjudicationJobHandler)
    {
         bool terminate = false;
         while(!terminate) {
             try {
                 //My Logic           
                 completedAdjudicationJobHandler(1);
                 terminate = true;
             }
             catch(Exception ex) {
                 ex.Handle(ex =>
                 {
                     System.IO.File.AppendAllText(@"C://test.txt", "Error:" + ex.Message + "\r\n");
                     return true;
                 });
             }
         }
    }
