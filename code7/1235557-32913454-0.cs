    public PSDataCollection<PSObject> TestFifteenSub(string p_scriptText)
    {
      PowerShell ps = PowerShell.Create();
      ps.AddScript(p_scriptText);
      return ps.Invoke();
    }
    public List<PSObject> TestFifteen(string pStrFullFilePathFileNm)            
    {         
      PSDataCollection<PSObject> retval = null;
      List<PSObject> lstPsObjs = null;
      retval = TestFifteenSub(pStrFullFilePathFileNm);
      lstPsObjs = retval.ToList();
      return lstPsObjs;
    }
