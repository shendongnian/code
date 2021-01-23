    protected override void OnStart(string[] args)
            {
                  
                  Thread createComAndMessagePumpThread = new Thread(() =>
                  {
                      axCZKEM1 = new zkemkeeper.CZKEMClass();
                      connSatus = axCZKEM1.Connect_Net("192.169.9.34", 4370);
                      using (StreamWriter writer = new StreamWriter(filePath, true))
                      {
                          writer.WriteLine("Machine is connected on" + "Date :" + DateTime.Now.ToString() + "status" + connSatus);
                          writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                      }
    
                      if (connSatus == true)
                      {
    
                          this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
    
                          if (axCZKEM1.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                          {
    
                              this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                              using (StreamWriter writer = new StreamWriter(filePath, true))
                              {
                                  writer.WriteLine("finger print Event is registered... ");
                                  writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                              }
    
                          }
                      }
    
                     Application.Run();
                  });
                  createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);
    
                  createComAndMessagePumpThread.Start();
    
    
            }
