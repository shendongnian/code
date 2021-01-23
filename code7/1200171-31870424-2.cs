    private void bPing_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dgvData.Rows)
        {
            if(!row.IsNewRow)
            {
                String ip;
                Ping ping = new Ping();
                ip = row.Cells["cIPAddress"].Value.ToString();
                ping.PingCompleted += new   PingCompletedEventHandler(ping_PingCompleted);
    
                ping.SendAsync(ip, 1000, row);
    
                System.Threading.Thread.Sleep(5);
            }
        }
    }
