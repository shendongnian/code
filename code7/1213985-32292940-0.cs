    private async void button2_Click(object sender, EventArgs e){
        rec = new Thread(recV);
        ip = IPAddress.Parse(GetIp());
        sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        sck.Bind(new IPEndPoint(ip, port));
        sck.Listen(0);
        acc = await sck.AcceptAsync();
        //This will block here, let the UI thread continue and then resume when a connection is accepted
        /*while (true)
        {
            byte[] sdata = Encoding.ASCII.GetBytes("TEST");
            acc.Send(sdata, 0, sdata.Length, 0);
        }*/
    }
