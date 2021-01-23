    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;           
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
    BackgroundWorker worker = new BackgroundWorker();
    worker.DoWork += (s, ev) =>
    {
       addItems(DataCollection,listView1);
    };
    worker.RunWorkerCompleted += (s, ev) =>
    {
       textBox1.AutoCompleteCustomSource = DataCollection;     
    };
    worker.RunWorkerAsync();
