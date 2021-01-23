    using NativeWifi;
    public  void GetLog(int Count)
            {
                string Conectividade = "Disc";//Initi variable Conectividade as Disconnected
                string RRate = "0";//Initi variable RRate as 0
                string TRate = "0";//Initi variable TRate as 0
                WlanClient client = new WlanClient();
                foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)// Get the WLANs available
                {
                    Wlan.WlanAssociationAttributes conAttributes = wlanIface.CurrentConnection.wlanAssociationAttributes;//Get the Attributes of current connection 
                    string ConnectedSSID = Encoding.ASCII.GetString(conAttributes.dot11Ssid.SSID).ToString();//Save the SSID of WLAN connected with
                    string ReceivedRate = conAttributes.rxRate.ToString();//Save the receipted rate of the connected WLAN
                    string TransmitededRate = conAttributes.txRate.ToString();//Save the transmitted rate of the connected WLAN    
                    byte[] ConnectedMacAddr = conAttributes.dot11Bssid;//MAC of the BSSID in which the WLAN is connected with
                    string ConMac = "";
                    for (int i = 0; i < ConnectedMacAddr.Length;                    {
                        ConMac += ConnectedMacAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();//ConMac sera o MAC da BSSID conectada
                    }
    
                    Wlan.WlanBssEntry[] wlanBssEntries = wlanIface.GetNetworkBssList();//Vector with the BSS available
                    Wlan.WlanAvailableNetwork[] wlanAvailableNetwork = wlanIface.GetAvailableNetworkList(0);//Vector with the WLANS available
                    WriteLog("\"ID" + listSeparatorQuotes + "DateTime" + listSeparatorQuotes + "SSID" + listSeparatorQuotes + "MAC" + listSeparatorQuotes + "Type" + listSeparatorQuotes + "Auth" + listSeparatorQuotes + "Cipher" + listSeparatorQuotes + "Connection" + listSeparatorQuotes + "RecivRate" + listSeparatorQuotes + "TransmiRate" + listSeparatorQuotes + "SignalQuality" + listSeparatorQuotes + "NumberOfBSSIDS\"", path, "WLANs" + StartDay + StartHour + ".csv");
                    foreach (Wlan.WlanAvailableNetwork AVnetwork in wlanAvailableNetwork)
                    {
                        string SSIDatual = Encoding.ASCII.GetString(AVnetwork.dot11Ssid.SSID).ToString();//Actual SSID
                        if(SSIDatual.Equals(ConnectedSSID))
                        {
                            Conectividade = "Con";
                            RRate = ReceivedRate;
                            TRate = TransmitededRate;
                        }
                        //___________________________ wlanAvailableNetwork ___________________________
                        WriteLog(Count.ToString() + listSeparator + System.DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") + listSeparator + SSIDatual + listSeparator + ConMac + listSeparator +  AVnetwork.dot11BssType + listSeparator + AVnetwork.dot11DefaultAuthAlgorithm + listSeparator + AVnetwork.dot11DefaultCipherAlgorithm + listSeparator + Conectividade + listSeparator + RRate + listSeparator + TRate + listSeparator + AVnetwork.wlanSignalQuality + listSeparator + AVnetwork.numberOfBssids + "\"", path, "WLANs" + StartDay + StartHour + ".csv");//Its a function that's writes a log in the selected path...case you need this function send me a message!
                        //_________________________ End wlanAvailableNetwork _________________________
                        Conectividade = "Disc";//Reinitialize the value of Conectividade                        RRate = "0";//Reinitialize the value of RRate
                        TRate = "0";//Reinitialize the value of TRate
                    }
                    foreach (Wlan.WlanBssEntry network in wlanBssEntries)// Get all existent BSSIDs
                    {
                        int rss = network.rssi;
                        byte[] macAddr = network.dot11Bssid;
                        string tMac = "";
    
                        for (int i = 0; i < macAddr.Length; i++)
                        {
                            tMac += macAddr[i].ToString("x2").PadLeft(2, '0').ToUpper();
                        }
    
                        //___________________________ wlanBSSEntries __________________________
                        WriteLog(Count.ToString() + listSeparator + System.DateTime.Now.ToString("MM/dd/yyyy  HH:mm:ss") + listSeparator + System.Text.ASCIIEncoding.ASCII.GetString(network.dot11Ssid.SSID).ToString() + listSeparator + network.dot11BssType + listSeparator + network.chCenterFrequency + listSeparator + network.linkQuality + listSeparator + rss.ToString() + listSeparator + tMac, path, "BSSIDs" + StartDay + StartHour + ".csv");
                        //_________________________ End wlanBSSEntries _________________________
    
    
    
                    }
                    Console.ReadLine();
                }
            }
