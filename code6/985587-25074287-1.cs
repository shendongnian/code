    Tbl_Patient patientObject = new Tbl_Patient();
    string[] spID = sid.Split('-');
    patientObject.PID = pid;
    patientObject.SID = sid;
    patientObject.Seq = spID[1];
    patientObject.Address = address;
    patientObject.Phone = phone;
    Tbl_Inter inteObject = null;
    // does this CheckExist function have to hit the database, or can it avoid that?
    if (_interClient.CheckExist(patientObject.PID) == 0)
      {
      inteObject = new Tbl_Inter();
      inteObject.PID = patientObject.PID;
      inteObject.Address = patientObject.Address;
      inteObject.DateIN = patientObject.DateIN;
      }
    using (var con = new SqlConnection(ConfigurationSettings.AppSettings["Main.ConnectionString"]))
      {
      con.Open();
      using( var tx = con.BeginTransaction("SampleTransaction") )
        {
        try
          {
          _paClient.Insert(patientObject, con, tx);
          if( null != inteObject )
            {
            _paClient.Insert(inteObject, con, tx);
            }
          tx.Commit();
          }
        catch( Exception ex )
          {
          try{ transaction.Rollback(); }
          catch( Exception ex2 )
            {
            // lame that this is necessary if you're not using implicit rollback
            // write to log, whatever...
            }
          throw; //re-throw the original exception w/call stack for logging by your global exception handler
          }
        }
      }
