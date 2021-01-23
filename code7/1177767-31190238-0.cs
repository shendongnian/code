    public partial class Form1 : Form
    {
	    CancellationTokenSource cancelSource = new CancellationTokenSource();
	    int threadCounter = 0;
	    int mainCounter = 0;
	    public void doSomeStuff(CancellationToken cancelToken)
	    {
		    cancelToken.ThrowIfCancellationRequested();
		    for (int i = 0; i < 100; i++)
		    {
			    threadCounter = i;
			    // If you want to cancel the thread just call the Cancel method of the cancelSource.
			    if (i == 88)
			    {
				    cancelSource.Cancel();
			    } 
			
			    if (cancelSource.IsCancellationRequested)
			    {
				    // Do some Thread clean up here
			    }
		    }
	    }
	    private void button1_Click(object sender, EventArgs e)
	    {
		    new Thread(() => doSomeStuff(cancelSource.Token)).Start();
		    // Do something else while the thread has not been cancelled
		    while (!cancelSource.IsCancellationRequested)
		    {
			    mainCounter++;
		    }
		    textBox1.Text = "The thread was cancelled when 'mainCounter' was at: " + mainCounter.ToString();            
	    }
    }
