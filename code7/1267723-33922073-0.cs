    public void button1_Click(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(textBox1.Text))
        {
            MessageBox.Show("Please enter an asset tag number.", "Dramatic failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        else
        {
            string assetTag = textBox1.Text;
            Ping pingSender = new Ping();
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1000;
            PingOptions options = new PingOptions(64, true);
            
            try
            {            
                PingReply reply = pingSender.Send("WES0" + assetTag);
                if (reply.Status == IPStatus.Success)
                {
                    MessageBox.Show("The IP address is: ", "Great sucess!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error on ping!", "Error on ping!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error on ping:" + ex.Message, "Error on ping!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
