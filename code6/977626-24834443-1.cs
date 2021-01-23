    void parserBackgroundWorker_DoWork(object sender,
            DoWorkEventArgs e)
    {
         // do stuff
         var parserResult = parser.Parse((SegmentFile)e.Argument);
 
         // set the Result property with a custom object which 
         // will allow you to know which case you need to handle
         // this can be simply: e.Result = e.Argument;
         // or, you can create an instance of your own class, something like:
         e.Result = new WorkerResult(e.Argument, parserResult);
    }
