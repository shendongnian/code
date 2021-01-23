      Classfinename objEvents = new Classfinename ();
    private void BindContrydropdown()
        {
            try
            {
                DataSet dsLang = objEvents.Getalllanguages();
                if (dsLang.Tables[0].Rows.Count > 0)
                {
                    ddllang.DataTextField = "Languages";
                    ddllang.DataValueField = "LanguageId";
                    ddllang.Items.Clear();
                    ddllang.DataSource = dsLang;
                    ddllang.DataBind();
                    ddllang.Items.Insert(0, new ListItem("Please Select"));
                }
            }
            catch (Exception ex)
            {  }
        }
