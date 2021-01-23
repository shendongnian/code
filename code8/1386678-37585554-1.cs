     try
     {
          ModbusTCP localWork = work;
          Thread thread = new Thread(
               new ThreadStart(
                   () => localWork.StartReadHoldingRegister())) 
                   { 
                      Name = ((ReadHoldingRegisterParam) localWork.SetReadHoldingRegisterParam).id.ToString(), 
                      IsBackground = true };
                   });
           localWork.OnResponseEvent += new EventHandler<ModbusTCP.ResponseEventArgs>(modbus_OnResponseEvent);
           localWork.OnExceptionEvent += new EventHandler<ModbusTCP.ExceptionEventArgs>(modbus_OnExceptionEvent);                                            
