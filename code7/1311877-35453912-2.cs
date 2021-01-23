     public static void StartADebugerInterComCall(IpcCarier SetterDataObj)
    {
        IpcAccessorSetting curSrv = new IpcAccessorSetting(IpcMMf.IPChannelS.Debugger, IpcAccessorThreadNameS.DebuggerThrdCurProj, 0, 5000);
        StartCurProjInterCom(curSrv, 10000);
                    
        var dataW = SetterDataObj.IpcCarierToByteArray();//System.Text.Encoding.UTF8.GetBytes(msg);
        CurProjMMF.Write(dataW);
        CurProjMMF.flagReciver1.Set();
        CurProjMMF.flagCaller1.WaitOne();
        CurProjMMF.flagCaller1.Reset();
        //MMFInterCom.flagCaller2.WaitOne();
        //MMFInterCom.flagCaller2.Reset();
    }
