            protected void Page_Load(object sender, EventArgs e)
            {
               
            }
            protected void Page_init(object sender, EventArgs e)
            {
                CheckBox cb = new CheckBox();
                cb.AutoPostBack = true;
                cb.CheckedChanged +=cb_CheckedChanged;
                cb.CausesValidation = false;
                cb.ToolTip = "Hello";
                cb.ID = "chk_test";
    
                Label lbl = new Label();
                lbl.Text = "test";
                lbl.AssociatedControlID = cb.ID;
    
                dvCheckboxes.Controls.Add(cb);
                dvCheckboxes.Controls.Add(lbl);
                dvCheckboxes.Controls.Add(new LiteralControl("<br />"));
            }
            protected void cb_CheckedChanged(object sender, EventArgs e)
            {
                
                System.Diagnostics.Debug.Write(((CheckBox)sender).ToolTip);
            }
