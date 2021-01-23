    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	// Load file list here
    	int totalImageCount = 10000;
    	// Set maximum value of the progress bar
    	progressBar1.Invoke(new Action(() => { progressBar1.Maximum = totalImageCount; }));
    
    	for (int i = 0; i < totalImageCount; i++)
    	{
    		// Load a single image here
    		Thread.Sleep(10);
    
    		// User cancelled loading (form shut down)
    		if (e.Cancel) return;
    		// Set the progress
    		progressBar1.Invoke(new Action(() => { progressBar1.Value = i; }));
    	}
    
    	// Cleanup here
    }
    
    // Starts the loading
    private void button1_Click(object sender, EventArgs e)
    {
    	// Start loading images
    	backgroundWorker1.WorkerSupportsCancellation = true;
    	backgroundWorker1.RunWorkerAsync();
    }
    
    // Stops the loading
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
    	// Stop the loading when the user closes the form
    	if (backgroundWorker1.IsBusy) backgroundWorker1.CancelAsync();
    }
