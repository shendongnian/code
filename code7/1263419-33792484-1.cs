    private async void button1_Click(object sender, EventArgs e)
    {
        button1.Visible = false;
        progressBar1.Minimum = 0;
        progressBar1.Maximum = 231;
        // Set up a callback that can be used to report progress on the UI thread
        Progress<int> progress = new Progress<int>(i =>
        {
            progressBar1.Value = i;
            if (progressBar1.Value == 220)
            {
                button1.Visible = true;
            }
        });
        // Perform your task; this will run in a different thread from the current,
        // UI thread, allowing the UI thread to do useful things like hiding the button
        // and updating the progress bar. Use of "await" here is what allows this
        // method to return, _temporarily_, so that the UI thread can continue to work
        await Task.Run(() =>
        {
            for (i = 0; i <= 220; i++)
            {
                // do NOT do this in real code...this is just here to represent _some_ kind
                // of time-consuming operation that justifies the use of the progress bar
                //in the first place
                Thread.Sleep(250);
                // Now report the progress value; the "progress" object will handle
                // marshaling back to the UI thread to call the anonymous method
                // declared above during the initialization of "progress"
                progress.Report(i);
            }
        });
        // Do any post-processing cleanup, UI updating, etc. here. This code
        // will execute only after the task started above has completed.
    }
