    if(!IsPostBack)
      {
            rdYes = new CheckBox();
            rdYes.Text = "Yes";
            rdYes.Checked = false;
            rdYes.AutoPostBack=false;
            rdNo = new CheckBox();
            rdNo.Text = "No";
            rdNo.Checked = false;
            rdNo.AutoPostBack=false; 
      }
