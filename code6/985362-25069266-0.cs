    // Loop to receive all the data sent by the client. 
                        while ((i = networkStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            //System.Diagnostics.Debugger.Launch();
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Utility.WriteLog("Received: " + data);
                            string CartCommand = data;
                            #region PROCESSING AT COMMAND AT FIRMWARE
                            try
                            {
                                string SerialResponse = string.Empty;
                                CreateSerialPort();
                                if (_serialPort.IsOpen == false)
                                {
                                    _serialPort.Open();
                                }
                                
                                _serialPort.Write(CartCommand); /* Execute Network Supplied Command to Serial Port */
                                Thread.Sleep(_ResponseWait);
                                byte[] SPResponsebyte = new byte[_serialPort.ReadBufferSize];
                                int intSPtBytes = _serialPort.Read(SPResponsebyte, 0, SPResponsebyte.Length); /* Read the Serial Port Response after Command Execution */
                                SerialResponse = System.Text.Encoding.ASCII.GetString(SPResponsebyte, 0, intSPtBytes);
                                SPResponsebyte = System.Text.Encoding.ASCII.GetBytes(SerialResponse);
                                networkStream.Write(SPResponsebyte, 0, SPResponsebyte.Length);
                                Utility.WriteLog(SerialResponse);
                            }
                            catch (Exception ex)
                            {
                                Utility.WriteLog("Error: " + ex.Message);
                                
                                byte[] SPResponsebyte = new byte[_serialPort.ReadBufferSize];
                                SPResponsebyte = System.Text.Encoding.ASCII.GetBytes("COMERROR"); // explicitly initializing with blank response
                                networkStream.Write(SPResponsebyte, 0, SPResponsebyte.Length); // force output to network stream
                                Utility.WriteLog("Blank response sent back to network stream");
                                // This is the problem area, the while loop don't accept next commands after this.
                            }
                            #endregion
                        }
