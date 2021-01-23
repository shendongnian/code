    private System.Threading.Timer timer = new System.Threading.Timer(Callback);
    public Form()
    {
        InitializeComponent();
        timer.Change(0, 1000);
    }
    private void Callback(object state)
    {
        DateTime dtime = DateTime.Now;
        string date_time = dtime.ToString("dd/MM/yyyy HH:mm:ss");
        button1.Invoke((MethodInvoker)delegate { textBox1.Text = date_time; });
    }
