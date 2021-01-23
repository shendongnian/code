    MyWorkerObject myObject;
    // This method is executed on the worker thread. Do not access your controls
    // in the main thread from here directly.
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        myObject = new MyWorkerObject();
        // The following line is a blocking operation in this thread.
        // The user acts in the UI thread, not here, so you cannot do here
        // anything but wait.
        myObject.DoWork();
        // Now DoWork is finished. Next line is needed only to notify
        // the caller of the event whether a cancel has happened.
        if (backgroundWorker1.CancellationPending)
            e.Cancel = true;
        myObject = null;
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
       if (backgroundWorker1.IsBusy)
       {
           backgroundWorker1.CancelAsync();
           // You must notify your worker object as well.
           // Note: Now you access the worker object from the main thread!
           // Note2: It would be possible to pass the worker to your object
           //        and poll the backgroundWorker1.CancellationPending from there,
           //        but that would be a nasty pattern. BL objects should not
           //        aware of the UI components.
           myObject.CancelWork();
       }
    }
