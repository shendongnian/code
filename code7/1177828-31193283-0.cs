    public partial class Form1 : Form
    {
        int loopCounter = 0;  		// variable just used for illustration      
        private static BackgroundWorker bw = new BackgroundWorker();		// The worker object
        
        // This function does your task
		public void doSomeStuff(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                loopCounter = i;    // Pass the loop count to this variable just to report later how far the loop was when the worker got cancelled.
                Thread.Sleep(100);  // Slow down the loop
                
                // During your loop check if the user wants to cancel
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    return; // quit loop
                }
            }
        }
		
        // This button starts your task when pressed
		private void button1_Click(object sender, EventArgs e)
        {
            bw.WorkerSupportsCancellation = true;   // Set the worker to support cancellation
            bw.DoWork += doSomeStuff;               // initialize the event
            if (!bw.IsBusy)                         // Only proceed to start the worker if it is not already running.
            {
                bw.RunWorkerAsync();                // Start the worker
            }
        }
        // This button stops your task when pressed
		private void button2_Click(object sender, EventArgs e)
        {
            // Request cancellation
            bw.CancelAsync();
            textBox1.Text = "The bw was cancelled when 'loopCounter' was at: " + loopCounter.ToString();
            
        }
    }
