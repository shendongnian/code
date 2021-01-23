                while (true)
                {
                    Thread.Sleep(60 * 1 * 100);
                    gunler.Clear();
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        gunler.Add(queryObj["ProviderName"].ToString().Substring(2,7));
                        //MessageBox.Show("Caption: " + queryObj["ProviderName"] + " ---" + queryObj["FileSystem"]);
                    }
                    
                    // Console.WriteLine("*** calling MyMethod *** ");
                    IPAddress ip = IPAddress.Parse("192.168.1.123");
                    //IPAddress hostn = IPAddress.Parse("ADS-201");
                    Ping ping = new Ping();
                    var reply = ping.Send(ip);
                   // var hosreply = ping.Send(hostn);
                    if (reply.Status == IPStatus.Success)
                    {
                        if (gunler.Contains("ads-201") || gunler.Contains("ADS-201"))
                        {
                            MessageBox.Show("ADS-201 is exist");
                        }
                        else
                        {
                            MessageBox.Show("ADS-201 does not exist!");
                           
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("No ping to hostname!");
                    }
                   // yuor_method();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
           }
