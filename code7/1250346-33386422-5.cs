    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
    	System.Threading.Thread.Sleep(5000);
    	e.Result = new string[] { "one", "two" };
    }
    private void backgroundWorker1_RunWorkerCompleted(
    	object sender,
    	RunWorkerCompletedEventArgs e)
    {
    	string[] res = (string[])e.Result;
    	this.textBox1.Text = res[0];
    }
