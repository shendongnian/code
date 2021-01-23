       rdYes = new CheckBox();
       rdYes.ID = "chkYes";
       rdYes.Text = "Yes";
       rdYes.Checked = false;
       rdYes.AutoPostBack=false;
       rdYes.Attributes.Add("onclick","ToggleCheckboxes();return false") 
       rdNo = new CheckBox();
       rdNo.ID = "chkNo";
       rdNo.Text = "No";
       rdNo.Checked = false;
       rdNo.AutoPostBack=false; 
       rdNo.Attributes.Add("onclick","ToggleCheckboxes();return false")
    
