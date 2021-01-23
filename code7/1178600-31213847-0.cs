    private List<Socket> samp = new List<Socket>();
    
    private void button1_Click(object sender, EventArgs e)
    {   
            //If you don't want the error
            //if(samp.Count > 0) return;
            IPHostEntry host = null;
            Socket sock;
            host = Dns.GetHostEntry(entered_ip);
    
            foreach (IPAddress address in host.AddressList)
            {
    
                IPEndPoint ipe = new IPEndPoint(address, 7779);
                sock = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
    
                sock.Connect(ipe);
    
                if (sock.Connected)
                {
                    enable_anticheat();
                    samp.Add(sock);
                    Process.Start("samp://" + entered_ip + ":" + entered_port);
                    break;
                } //The else continue is unnecessary. 
            }
    }
    
    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if(samp.Count > 0) {
          foreach(Socket s: samp) {
             s.close();             
          }
        }
    }
