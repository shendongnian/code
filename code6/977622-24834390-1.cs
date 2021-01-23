    class ParserWorkerParameters
    {
        public String SegFile { get; set; }
        public Action CallBack { get; set; }
        public ParserWorkerParameters(string segFile, Action callBack)
        {
           SegFile = segFile;
           CallBack = callBack;
        }
    }
    parserBackgroundWorker.RunWorkerAsync(new ParserWorkerParameters("someString", () =>  MessageBox.Show("worker complete")));
    private void parserBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        ParserWorkerParameters param = e.Argument as ParserWorkerParameters;
        parser.Parse((SegmentFile)param.SegFile);
        e.Result = param;
    }
    private void parserBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        //old code
        ParserWorkerParameters param = e.Result as ParserWorkerParameters;
        if (param.CallBack != null)
        {
            param.CallBack();
        }
    }
