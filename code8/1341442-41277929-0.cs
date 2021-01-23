            File.WriteAllText("your rasphone.pbk  path","")//Add
            string vpnuser = txt_vpn_user.Text;
            string ip_address = txt_IP.Text;
            this.rasPhoneBook1.Open();
            RasEntry entry = RasEntry.CreateVpnEntry(vpnuser, ip_address, RasVpnStrategy.Default, RasDevice.GetDeviceByName("(PPTP)", RasDeviceType.Vpn, false));
            this.rasPhoneBook1.Entries.Add(entry);
            MessageBox.Show("Success");
        }
