     public void btnPing_Click(object sender, EventArgs e)
        {
            try
            {
                int intCount = 0;
                int maxip = 0;
                richTmp.Clear();
                string strIP = null;
                string machineName = string.Empty;
                List<string> strListIp = new List<string>();
                List<string> txtBuffrFile = new List<string>();
                BufferdIp = new List<string>();
               
                for (int i = 1; i <= 30; i++)
                {
                   System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
                   lstDetails.Items.Add("System Found: " + maxip);
                   System.Net.NetworkInformation.PingReply rep = p.Send("192.168.1." + i,500);
                    if (rep.Status == System.Net.NetworkInformation.IPStatus.Success)
                    {
                        intCount++;
                        lstDetails.Items.Clear();
                        lstDetails.Items.Add("Loading...Total(" + maxip+")");
                        strIP = rep.Address.ToString();
                        machineName = GetMachineNameFromIPAddress(strIP);
                       if (machineName == string.Empty || machineName == null)
                        {
                            strListIp.Add(strIP + ":-" + "Offline");
                            BufferdIp.Add("0");
                        }
                        else
                        {
                            strListIp.Add(strIP + ":-" + machineName+"(Online)");
                            BufferdIp.Add(strIP);
                            txtBuffrFile.Add(strIP);
                            maxip++;
                        }
                    }
                  
                }
                lstDetails.Items.Clear();
                foreach (var IDAddres in strListIp)
                {
                    lstDetails.Items.Add(IDAddres);
                }
                for (int i = 0; i != txtBuffrFile.Count;i++ )
                {
                    richTmp.Text += txtBuffrFile.ElementAt(i) + "\n";
                }
                if (MessageBox.Show("Do you want to Save This Search", "Save Dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == (DialogResult.Yes))
                {
                    if(File.Exists (path))
                    File.Delete(path);
                    FileStream stream = File.Create(path);
                    stream.Close();
                    File.WriteAllText(path, richTmp.Text, Encoding.UTF8);
                }
                btnConnct.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
