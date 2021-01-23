    public byte[] GetMemory(uint offset, byte[] buffer)
    {
      if (SetAPI.API == SelectAPI.TargetManager)
        return Common.TmApi.GetMemory(offset, buffer);
      else if (SetAPI.API == SelectAPI.ControlConsole)
        return Common.CcApi.GetMemory(offset, buffer);
      else
       throw new NotImplementedException();
    }
