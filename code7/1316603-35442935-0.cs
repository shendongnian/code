            static bool MMfGetterTest1()
            {
    
                IpcAccessorSetting parCurSrv = new IpcAccessorSetting(IPChannelS.Debugger, IpcAccessorThreadNameS.DebuggerThrd, 0, 5000000);
                MMFinterComT DebuggerInterReciver=null;
    
                    DebuggerInterReciver = new MMFinterComT(parCurSrv.Channel.ToString(), parCurSrv.AccThreadName.ToString(), 10000000);
                    DebuggerInterReciver.ReadPosition = parCurSrv.AccessorSectorsSets.DepoSects.Getter.Read;
                    DebuggerInterReciver.WritePosition = parCurSrv.AccessorSectorsSets.DepoSects.Getter.Write;
                    DebuggerInterReciver.flagReciver1 = new EventWaitHandle(false, EventResetMode.ManualReset, DebuggerInterReciver.DipositThrdName);
                    DebuggerInterReciver.flagReciver2 = new EventWaitHandle(false, EventResetMode.AutoReset, IpcAccessorThreadNameS.DebuggerThrdCurProj.ToString());
                    DebuggerInterReciver.flagCaller1 = new EventWaitHandle(false, EventResetMode.ManualReset, IpcAccessorThreadNameS.DebuggerThrdCurProj.ToString());
                    DebuggerInterReciver.flagCaller2 = new EventWaitHandle(false, EventResetMode.ManualReset, IpcAccessorThreadNameS.DebuggerThrdCurProj.ToString());
                    System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                   MbxTwDbSrv.Show(320, "Debugger Reciver Online ", "V", "Debugger Reciver Ready on\r\nDebuggerInterReciver.ReadPosition " + DebuggerInterReciver.ReadPosition + "\r\nDebuggerGetterepo.WritePosition " + DebuggerInterReciver.WritePosition)), System.Windows.Threading.DispatcherPriority.Normal);
                    DebuggerInterReciver.flagCaller1.Set();
                    DebuggerInterReciver.flagReciver1.WaitOne();
                    DebuggerInterReciver.flagReciver1.Close();
    
    
                DebuggerInterReciver.flagReciver2.WaitOne(200);
                bool exit = false; int trys = 0;
                while(!exit)
                {
    
        
                    DebuggerInterReciver.StartReader();
                    System.Windows.Application.Current.Dispatcher.Invoke(new     Action(() =>
    MbxTwDbSrv.Show(336, "Debugger Reciver Reading Failure ", "X", "Debugger Reciver read status on try: # "+ ++trys + " "+DebuggerInterReciver.IntercomStatus)), System.Windows.Threading.DispatcherPriority.Normal); 
    
                  
                        DebuggerInterReciver.flagReciver2.WaitOne(700);
                        exit = DebuggerInterReciver.IntercomStatus==RobCs511C.AppMods.Selectors.IPC.IpcMMFinterComSF.MMFinterComTStatus.FinishedReading;
                }
            
                //DebuggerInterReciver.flagCaller.Set();
                DebuggerInterReciver.flagReciver2.Close();
                DebuggerInterReciver.flagCaller2.Set();
                
                  var x = DebuggerInterReciver.ReadData.BytesToIpcCarier().AsDebggerCarier();
                  System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
                    MbxTwDbSrv.Show(337, "Debugger Reciver OnReciveMessage: ", "V", "Debugger Reciver Has Recived Data: " + x.DvalStr +", Len= "+ x.DvalIntArr.Length)), System.Windows.Threading.DispatcherPriority.Normal);
                  DebuggerInterReciver.reading = false;
                return true;
    
            }
