	IPSegment ip = new IPSegment(txtip.Text.ToString(), SubNetMask());
                    Console.WriteLine(ip.NumberOfHosts);
                    Console.WriteLine(ip.NetworkAddress.ToIpString());
                    Console.WriteLine(ip.BroadcastAddress.ToIpString());
                    Console.WriteLine("===");
	foreach (var host in ip.Hosts())
                        {
                     string query = "insert into tblIPAddress(IP_Address) values('" + host.ToIpString() + "')";
                     OleDbCommand cmd = new OleDbCommand(query);
                     cmd.Connection = myConn;
                     myConn.Open();
                     cmd.ExecuteNonQuery();
                     myConn.Close();
			 }
