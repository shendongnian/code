            private void timer2_Tick(object sender, EventArgs e)
        {
            pingServer();
        }
        void pingServer()
        {
            if (_serverSocket != null || sockState == MySocketState.Connected)
            {
                Console.WriteLine("Ping Server");
                AllBytes = ASCIIEncoding.ASCII.GetBytes(COM_DeviceIsOnline);
                //_serverSocket.BeginSend(AllBytes, 0, AllBytes.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
                SendTCPData(0x01, 1, 1, 1, "AA", "");
            }
        }
        public bool SendTCPData(byte bySequenceNo, int nSlaveID, int nDeviceID,
                                int nStatus, String strCommand, String strData)
        {
            return SendTCPData(ACK, bySequenceNo, nSlaveID, nDeviceID, nStatus, strCommand, strData);
        }
        public bool SendTCPData(byte byTypeCode, byte bySequenceNo,
                                int nSlaveID, int nDeviceID,
                                int nStatus, String strCommand,
                                String strData)
        {
            return SendTCPData(byTypeCode, bySequenceNo, nSlaveID, nDeviceID,
                                nStatus, strCommand, strData, 0);
        }
        public bool SendTCPData(byte byTypeCode, byte bySequenceNo,
                                int nSlaveID, int nDeviceID,
                                int nStatus, String strCommand, String strData, int nProtocolType)
        {
            byte[] AllBytes;
            String strTemp;
            try
            {
                strTemp = nSlaveID.ToString("0#") +
                  nDeviceID.ToString("0#") +
                  nStatus.ToString() +
                  strCommand + strData;
                if (nProtocolType == 0)
                {
                    AllBytes = new byte[strTemp.Length + 7];
                    AllBytes[0] = SOH;
                    AllBytes[1] = byTypeCode;
                    AllBytes[2] = (byte)((int)bySequenceNo | 0x80);
                    AllBytes[3] = STX;
                    ASCIIEncoding.ASCII.GetBytes(strTemp).CopyTo(AllBytes, 4);
                    AllBytes[AllBytes.Length - 3] = ETX;
                    AllBytes[AllBytes.Length - 2] = 128;
                    AllBytes[AllBytes.Length - 1] = EOT;
                }
                else
                {
                    AllBytes = new byte[strTemp.Length + 6];
                    AllBytes[0] = SOH;
                    AllBytes[1] = STX;
                    ASCIIEncoding.ASCII.GetBytes(strTemp).CopyTo(AllBytes, 2);
                    AllBytes[AllBytes.Length - 4] = ETX;
                    AllBytes[AllBytes.Length - 3] = ETX;
                    AllBytes[AllBytes.Length - 2] = 128;
                    AllBytes[AllBytes.Length - 1] = EOT;
                }
                //Debug.WriteLine("Sending data to " + _sIPAddr + " -> " + ASCIIEncoding.ASCII.GetString(AllBytes));
                return SendByte(AllBytes, AllBytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
        public bool SendByte(byte[] pByteData, int nLength)
        {
            try
            {
                if  (_serverSocket == null) return false;
                if (!_serverSocket.Connected) return false;
                Console.WriteLine("SendByte = " + ASCIIEncoding.ASCII.GetString(pByteData, 0, nLength));
                //Debug.WriteLine("SendByte Length= " + nLength.ToString() );
                _serverSocket.BeginSend(pByteData, 0, nLength, SocketFlags.None,
                    SendCallback, _serverSocket);
                //dtLastActivity = DateTime.Now;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                CloseSocket();
            }
            return false;
        }
