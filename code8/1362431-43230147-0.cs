    Thread createComAndMessagePumpThread = new Thread(() =>
                {
                    device2FingersList[deviceIp] = new CZKEMClass();
                    connSatus = device2FingersList[deviceIp].Connect_Net(deviceIp, 4370);
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine("HR Machine is connected  at the" + "Date :" + DateTime.Now.ToString() + "status" + connSatus);
                        writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                    }
    
                    if (connSatus == true)
                    {
                        device2FingersList[deviceIp].OnVerify -= new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                        device2FingersList[deviceIp].OnConnected -= new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                        device2FingersList[deviceIp].OnAttTransaction -= new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                        device2FingersList[deviceIp].OnAttTransactionEx -= new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx);
                        device2FingersList[deviceIp].OnDisConnected -= new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                        if (device2FingersList[deviceIp].RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                        {
                            device2FingersList[deviceIp].OnVerify += new _IZKEMEvents_OnVerifyEventHandler(OnVerify);
                            device2FingersList[deviceIp].OnAttTransactionEx += new _IZKEMEvents_OnAttTransactionExEventHandler(OnAttTransactionEx2;
                            device2FingersList[deviceIp].OnAttTransaction += new _IZKEMEvents_OnAttTransactionEventHandler(OnAttTransaction);
                            device2FingersList[deviceIp].OnConnected += new _IZKEMEvents_OnConnectedEventHandler(OnConnected);
                            device2FingersList[deviceIp].OnDisConnected += new _IZKEMEvents_OnDisConnectedEventHandler(OnDisConnected);
                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine("attendnce transaction Events are registered... ");
                                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                            }
    
                        }
                    }
    
                    Application.Run();
                });
                createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);
                createComAndMessagePumpThread.Start();
            }
