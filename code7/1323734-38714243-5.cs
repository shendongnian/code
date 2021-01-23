    public zkemkeeper.CZKEM axCZKEM1 = new zkemkeeper.CZKEM();
    private void btndownload_Click(object sender, EventArgs e)
    {
         bool bIsConnected = axCZKEM1.Connect_Net(ip_address_of_your_machine, 4370);   // 4370 is port no of attendance machine
        if (bIsConnected == true)
        {
            bool delete = axCZKEM1.ClearGLog(dwMachineNumber);
            if (delete == true)
            {
                MessageBox.Show("Deleted.....");
            }
            if (delete == false)
            {
                MessageBox.Show("No Log Found To Delete.....");
            }
        }
    }
