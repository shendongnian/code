    public static bool StartCurProjInterCom(IpcAccessorSetting curSrv, int DepoSize)
    {
        if(CurProjMMF ==null)
        CurProjMMF = new MMFinterComT(curSrv.Channel.ToString(), curSrv.AccThreadName.ToString(), DepoSize);
        CurProjMMF.flagCaller1 = new EventWaitHandle(false, EventResetMode.ManualReset, CurProjMMF.DepositThrdName);
        CurProjMMF.flagCaller2 = new EventWaitHandle(false, EventResetMode.ManualReset, CurProjMMF.DepositThrdName);
        CurProjMMF.flagReciver1 = new EventWaitHandle(false, EventResetMode.ManualReset, IpcAccessorThreadNameS.DebuggerThrd.ToString());
        CurProjMMF.ReadPosition = curSrv.AccessorSectorsSets.DepoSects.Setter.Read;
        CurProjMMF.WritePosition = curSrv.AccessorSectorsSets.DepoSects.Setter.Write;
        Console.WriteLine("MMFInterComSetter.ReadPosition " + CurProjMMF.ReadPosition);
        Console.WriteLine("MMFInterComSetter.WritePosition " + CurProjMMF.WritePosition);
        CurProjMMF.StartReader();
        return true;
    }
