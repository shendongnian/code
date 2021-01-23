            /// <summary>
            /// Incoming bytes are retrieved in this method
            /// </summary>
            /// <param name="disconnected"></param>
            /// <returns></returns>
            private byte[] ReceivedBytes(ref bool disconnected)
            {
                try
                {
                    //byte[] myReadBuffer = new byte[1024];
                    int receivedDataLength = 0;
                    byte[] data = { };
                    int len = 0;
                    int i = 0;
                    PeerStream.ReadTimeout = 15000;
                    
                    
                    if (PeerStream.CanRead)
                    {
                        //networkStream.Read(byteLen, 0, 8)
                        byte[] byteLen = new byte[8];
                        if (_client.Client.IsConnected() == false)
                        {
                            //Fire Disconnect event
                            if (OnDisconnect != null)
                            {
                                disconnected = true;
                                OnDisconnect(this);
                                return null;
                            }
                        }
                        while (len == 0)
                        {
                            PeerStream.Read(byteLen, 0, 8);
    
                            len = BitConverter.ToInt32(byteLen, 0);
                        }
                        data = new byte[len];
    
                        PeerStream.Read(data, receivedDataLength, len);
                       
                        return data;
                    }
    
    
    
                }
                catch (Exception E)
                {
    
                    //System.Windows.Forms.MessageBox.Show("Exception:" + E.ToString());
                }
                return null;
            }
