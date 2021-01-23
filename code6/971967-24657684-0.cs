    private void button1_Click(object sender, EventArgs e)
    {
        byte[] packetData = Encoding.ASCII.GetBytes(textBox1.Text);
        const string ip = "75.126.77.26";
        const int port = 5588;
        var ep = new IPEndPoint(IPAddress.Parse(ip), port);
        var client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ep);
        client.SendTo(packetData, ep);
    }
