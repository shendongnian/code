        public void GetDetails2()
        {
            using (var worker = new BackgroundWorker())
            {
                worker.WorkerReportsProgress = true;
                worker.WorkerSupportsCancellation = true;
                worker.DoWork += delegate (object s, DoWorkEventArgs e)
                {
                    var w = (BackgroundWorker)s;
                    var bc = new BasicClass();
                    bc.Products = new ObservableCollection();
                    bc.Suppliers = new ObservableCollection();
                    using (var dataDc = new Genesis_DataDataContext())
                    {
                        // dbl_Products may use a Data Reader, so use an index.
                        // This may or may not produce an error, depending on how the Genesis_DataDataContext is designed.
                        for (int i = 0; i < dataDc.tbl_Products.Count; i++) {
                            w.ReportProgress(i + 1, dataDc.tbl_Products.Count);
                            var item = dataDc.tbl_Products[i];
                            bc.Products.Add(item);
                        }
                        w.ReportProgress(-1, "On to Suppliers.")
                        // dbl_Products may use a Data Reader, so use an index.
                        // This may or may not produce an error, depending on how the Genesis_DataDataContext is designed.
                        for (int i = 0; i < dataDc.tbl_Suppliers.Count; i++)
                        {
                            w.ReportProgress(i + 1, dataDc.tbl_Suppliers.Count);
                            var item = dataDc.tbl_Suppliers[i];
                            bc.Suppliers.Add(item);
                        }
                        e.Result = bc;
                    }
                };
                worker.ProgressChanged += delegate (object s, ProgressChangedEventArgs e)
                {
                    if (!worker.CancellationPending)
                    {
                        var index = e.ProgressPercentage;
                        var state = e.UserState.ToString();
                        int total;
                        if (int.TryParse(state, out total))
                        {
                            Console.WriteLine("{0} of {1}", index, total);
                        } else
                        {
                            Console.WriteLine(state);
                        }
                    } else
                    {
                        worker.CancelAsync();
                    }
                };
                worker.RunWorkerCompleted += delegate (object s, RunWorkerCompletedEventArgs e)
                {
                    IsBusy = false;
                    if (e.Error == null)
                    {
                        var bc = e.Result as BasicClass;
                        foreach (var item in bc.Products)
                        {
                            this.Products.Add(item);
                        }
                        foreach (var item in bc.Suppliers)
                        {
                            this.Suppliers.Add(item);
                        }
                    }
                };
                worker.RunWorkerAsync();
                IsBusy = worker.IsBusy;
            }
        }
