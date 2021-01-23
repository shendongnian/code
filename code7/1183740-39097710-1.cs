    public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
    private void btnconnect_Click(object sender, EventArgs e)
    {
        try
        {
            bool bIsConnected = axCZKEM1.Connect_Net(ip_address_of_your_machine, 4370);   // 4370 is port no of attendance machine
            if (bIsConnected == true)
            {
             MessageBox.Show("Device Connected Successfully");
            }
            else
            {
            MessageBox.Show("Device Not Connect");
            }
        }
        Catch( (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
        }
    }
