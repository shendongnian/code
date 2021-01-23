    public void ProcessModemMessages(string CommPort)
        {
            try
            {
                SerialPort spCommPort = new SerialPort();
                spCommPort.PortName = CommPort;
                spCommPort.BaudRate = 9600;
                spCommPort.Parity = Parity.None;
                spCommPort.DataBits = 8;
                spCommPort.StopBits = StopBits.One;
                spCommPort.Handshake = Handshake.None;
                spCommPort.Open();
                if (spCommPort.IsOpen)
                {
                    //Seems like entering the pin on the first start up prevents errors....
                    spCommPort.WriteLine("AT+CPIN=3434" + "\r\n");
                    Thread.Sleep(500);
                    spCommPort.WriteLine("AT+CMGF=0" + "\r\n");//type: 1 Text. 0 PDU
                    Thread.Sleep(200);
                    spCommPort.ReadExisting();
                    while (m_Run)
                    {
                        try
                        {
                            spCommPort.WriteLine("AT+CSQ" + "\r\n");
                            Thread.Sleep(200);
                            string sig = spCommPort.ReadExisting();                           
                            spCommPort.WriteLine("AT" + "\r\n");
                            Thread.Sleep(200);
                            spCommPort.WriteLine("ATE" + "\r\n");
                            Thread.Sleep(200);
                            spCommPort.Write("AT+CPMS=\"SM\",\"SM\",\"SM\"" + "\r\n");
                            Thread.Sleep(200);
                            //spCommPort.WriteLine("AT+CMGL=\"ALL\"" + "\r\n");
                            spCommPort.WriteLine("AT+CMGL=4" + "\r\n");
                            Thread.Sleep(2000);
                            string smsMessages = spCommPort.ReadExisting();
                            if (Environment.UserInteractive)
                            {
                                Console.WriteLine(smsMessages);
                            }
                            if (smsMessages.Contains("error"))
                            {
                                InsertError(smsMessages);
                            }
                                                     
							//delete msgs from sim
							spCommPort.WriteLine("AT+CMGD=1,1" + "\r\n");
							Thread.Sleep(200);							
                            
                        }
                        catch (Exception e)
                        {
                            //error opening modem
                            InsertError("ProcessModemMessages: " + e.ToString());
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                }
                else
                {
                    //error opening modem
                    InsertError("ProcessModemMessages: " + "Error when opening comm port");
                }
            }
            catch (Exception ex)
            {
                InsertError("ProcessModemMessages: " + ex.ToString());
            }
        }
		
		
		
