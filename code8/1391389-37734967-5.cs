    public void Page_Load(object sender, EventArgs e)
    {
      string parameter = Request["__EVENTARGUMENT"]; // parameter
      if(Request["__EVENTTARGET"] =="btnSave")
       { /*Do Something with the parameter = dr["ID"]*/}
    }
