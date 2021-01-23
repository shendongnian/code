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
