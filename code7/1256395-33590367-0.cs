    private async void Form1_Load(object sender, EventArgs e)
    {
        IPEndPoint end = new IPEndPoint(IPAddress.Any, 8000);
        TcpListener list = new TcpListener(end);
        list.Start();
        TcpClient client = await list.AcceptTcpClientAsync();
        label5.Text = client.Client.LocalEndPoint.ToString();
    }
