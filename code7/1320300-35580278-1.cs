    if ((System.Environment.GetCommandLineArgs().Length == 0))
    {
        sConnectionString = "0030002C0030002C00530041005000420044005F00440061007400650076002C0050004C006F006D0056004900490056";
    }
    else
    {
        sConnectionString = System.Environment.GetCommandLineArgs().GetValue(1).ToString();
    }
  
