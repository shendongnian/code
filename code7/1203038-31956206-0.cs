    public Form1()
    {
        InitializeComponent();
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync();
    }
    private void backgroundWorker1_DoWork(object sender,            System.ComponentModel.DoWorkEventArgs e)
    {
         // Your infinite loop here, example is given below
         for (int i = 0; i < 100000; i++)
         {
            Console.WriteLine(i);
             Thread.Sleep(1000);
         }
    }
