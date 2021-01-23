    Thread thread;
    CancellationTokenSource cts;
    Stopwatch regularSW = new Stopwatch();
    public Form1()
    {
        InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        cts = new CancellationTokenSource();
        thread = new Thread(new ThreadStart(() => threadtest(cts.Token)));
        thread.Start();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        cts.Cancel();
    }
    public void threadtest(CancellationToken cancellation)
    {
        while (!cancellation.IsCancellationRequested)
        {
            regularSW.Start();
            // Simulate a Thread.Sleep; returns true if cancellation requested.
            if (!cancellation.WaitHandle.WaitOne(5000))
            {
                regularSW.Stop();
                this.Invoke(() => label1.Text += "Sleep in: "
                    + regularSW.Elapsed
                    + Environment.NewLine);
            }
        }
    }
