    worker.WorkerSupportsCancellation = true;
    worker.WorkerReportsProgress = true;
    worker.ProgressChanged += (o, e) =>
    {
         //Here in e.ProgressPercentage you will get the current line number read you can deduct the textblock text and progressbar value to be set on CurrentLineNumberAddedToListView and NumberOfLinesOfStringInTextFile
    }
    worker.DoWork += (o, ea) =>
            {
                List<String> listOfString = new List<string>();
                BackgroundWorker worker = o as BackgroundWorker;
                int numberofLine = 0;
                foreach (string lin in lines)
                {
                    listOfString.Add(lin);
                    
                    o.ReportProgress(++numberofLine);
                    Thread.Sleep(2);
                }
                
                
                Dispatcher.Invoke((Action)(() => _listBox.ItemsSource = listOfString));
            };
