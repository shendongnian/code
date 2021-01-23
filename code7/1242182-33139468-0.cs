     static uint str2ip(string ip)
        {
         //this converts the ip address from the textboxes to bytes
        string[] octets = ip.Split('.');
        uint x1 = (uint)(Convert.ToByte(octets[0]) << 24);
        uint x2 = (uint)(Convert.ToByte(octets[1]) << 16);
        uint x3 = (uint)(Convert.ToByte(octets[2]) << 8);
        uint x4 = (uint)(Convert.ToByte(octets[3]));
        return x1 + x2 + x3 + x4;
        }
      private volatile DataTable pingResults = new DataTable();
      //And I use str2ip in the button click event which contains this:
      private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
           {
                try
                {
                    pingResults.Clear();
                    uint startIP = str2ip(txtFrom.Text);
                    uint endIP = str2ip(txtTo.Text);
                    Parallel.For(startIP, endIP, index => pingIpAddress(ip2str(startIP++)));
                    Thread.Sleep(1000);
                    //for (uint currentIP = startIP; currentIP <= endIP; currentIP++)
                          //  {
                          //      string thisIP = ip2str(currentIP);
                          //      Thread myNewThread = new Thread(() => pingIpAddress(thisIP));
                          //      myNewThread.Start();
                               
                          //  }
                    dataGridView1.DataSource = pingResults;
                
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Exception {0} Trace {1}", ex.Message, ex.StackTrace));
                }
            }
            private void pingIpAddress(string ip3)
            {//this method is where I ping the IP addresses
                try
                {
                string ip2 = ip3;
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(ip2.ToString());
                var message = (pingReply.Status == IPStatus.Success) ? "On" : "Off";
                    lock (pingResults.Rows.SyncRoot)
                    {
                        AddToDataTable(ip2, message);
                    }
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(String.Format("Exception {0} Trace {1}", ex.Message, ex.StackTrace));
                }
            }
            private void AddToDataTable(string ip2,string msg)
            {
                try
                {
                    pingResults.Rows.Add(DateTime.Now.ToShortDateString(), ip2, GetMacAddress(ip2), msg.ToString(), GetMachineNameFromIPAddress(ip2));
              
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
