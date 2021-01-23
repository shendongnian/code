    //This is a bool to see if some other process is already running.
    if (isProcessRunning)
    {
         MessageBox.Show("Currently someone else is working!!!");
         return;
    }`var progressDialog = new ProgressDialog();
        //if you don't have a maximum value because you don't know how long it will take you should set indeterminate to true.
        progressDialog.setMaximum(<maximum value>);
        progressDialog.Text = "<what are you doing>";
        var backgroundThread = new Thread(() =>
                {
                    isProcessRunning = true;
                    //this does not have to be a loop, you can also do other stuff you just have to set you bar to indeterminate then.
                    foreach (<do my stuff>)
                    {
                        <do stuff here that takes time>
                        progressDialog.IncrementProgress();
                    }
                    //Close the progressdialog threadsave.
                    if (progressDialog.InvokeRequired)
                        progressDialog.BeginInvoke(new Action(() => progressDialog.Close()));
                    isProcessRunning = false;
                });
            backgroundThread.Start();
            progressDialog.ShowDialog();
