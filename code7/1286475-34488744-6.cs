    private void button9_Click(object sender, EventArgs e)
        {
            string serverIP = "192.168.3.213";
            bool result = PingHost(serverIP);
            if (result)
            {
                // connected successfully 
                // do the core logic here
            }
            else
            {
                MessageBox.Show("Unable to connect to server!, Check your Server IP address");
            }
        }
