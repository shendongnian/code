       private void btn1234_Click()
       {
            var items = ListBox1.SelectedItems.Cast<string>();
            backgroundWorker1.RunWorkerAsync(items);
        }
    
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            var items = (IEnumerable<string>)e.Argument;
            //Long Running Process taking place here  then we hit this
            if (items.Contains("Firefly")) { /* take this course */ }
            if (items.Contains("Hellfire")) { /* take this course */ }
        }
