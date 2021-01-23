    private Timer _timer;
    
    public Form() // Initialize timer in your form constructor
    {
        InitializeComponent();
        _timer = new Timer();
        _timer.Interval = 10000; // miliseconds
        _timer.Tick += _timer_Tick; // Subscribe timer to it's tick event
    }
    private void _timer_Tick(object sender, EventArgs e)
    {
        SendData();
    }
    private void cmd_send_Click_1(object sender, EventArgs e)
    {
        if (!_timer.Enabled) // If timer is not running send data and start refresh interval
        {
            SendData();
            _timer.Enabled = true;
        }
        else // Stop timer to prevent further refreshing
        {
            _timer.Enabled = false;
        }
    }
    private void SendData()
    {
        String processID = "";
        String processName = "";
        String processFileName = "";
        String processPath = "";
        string hostName = System.Net.Dns.GetHostName();
        listBox1.BeginUpdate();
        try
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                piis = GetAllProcessInfos();
                try
                {
                    // String pno = textBox4.Text.ToString();
                    // String path = textBox5.Text.ToString();
                    // String name = textBox6.Text.ToString();
                    // String user = textBox7.Text.ToString();
                    // output.Text += "\n Sent data : " + pno + " " + user + " " + name + " " + path ;
                    processID = piis[i].Id.ToString();
                    processName = piis[i].Name.ToString();
                    processFileName = piis[i].FileName.ToString();
                    processPath = piis[i].Path.ToString();
                    output.Text += "\n\nSENT DATA : \n\t" + processID + "\n\t" + processName + "\n\t" + processFileName + "\n\t" + processPath + "\n";
                }
                catch (Exception ex)
                {
                    wait.Abort();
                    output.Text += "Error..... " + ex.StackTrace;
                }
                NetworkStream ns = tcpclnt.GetStream();
                String data = "";
                //data = "--++" + "  " + textBox4.Text + " " + textBox5.Text + " " + textBox6.Text + " " + textBox7.Text;
                data = "--++" + "  " + processID + " " + processPath + " " + processFileName + " " + hostName;
                if (ns.CanWrite)
                {
                    byte[] bf = new ASCIIEncoding().GetBytes(data);
                    ns.Write(bf, 0, bf.Length);
                    ns.Flush();
                }
            }
        }
        finally
        {
            listBox1.EndUpdate();
        }
    }
