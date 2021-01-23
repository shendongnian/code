    private void Receive(IAsyncResult ar)
    {
        Socket client = (Socket)ar.AsyncState;
        client.EndReceive(ar);
        client.BeginReceive(byteData, 0, byteData.Length, //add BeginReceive again
            SocketFlags.None, new AsyncCallback(Receive), client);
        textBox1.Invoke(new Action(delegate ()
        {
            textBox1.AppendText(Environment.NewLine
                         + Encoding.ASCII.GetString(byteData));
        }));
        byteData = null;
    }
