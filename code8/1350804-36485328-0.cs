    private void button1_Click(object sender, EventArgs e)
    {
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sck.Bind(new IPEndPoint(0, 1234));
        System.Threading.Thread T = new System.Threading.Thread((new System.Threading.ThreadStart(Listener)));
        T.Start();
    }
    private void Listener()
    {
        sck.Listen(100);
        accepted = sck.Accept();
        Buffer = new byte[accepted.SendBufferSize];
        int bytesRead = accepted.Receive(Buffer);
        byte[] formatted = new byte[bytesRead];
        for (int i = 0; i < bytesRead; i++)
        {
            formatted[i] = Buffer[i];
        }
        string strData = Encoding.ASCII.GetString(formatted);
        panel1.Invoke((MethodInvoker)delegate
        {
            if (strData == "1")
                panel1.BackColor = Color.Red;
            else if (strData == "2")
                panel1.BackColor = Color.Blue;
        });
        sck.Close();
        accepted.Close();
    }
