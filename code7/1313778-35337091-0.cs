    protected void myRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            if (** condition 01 **)
            {
                if (** condition 02 **)
                {
                    RadioButton rdoBtn = new RadioButton();
                    rdoBtn.ID = "rbtnID";
                    rdoBtn.EnableViewState = true;
                    rdoBtn.GroupName = "GroupName";
                    rdoBtn.AutoPostBack = true;
                    rdoBtn.CheckedChanged += new System.EventHandler(this.rdoBtnChecked_Changed);
                    string script = "SetUniqueRadioButton('myRepeater.*GroupName',this)";
                    rdoBtn.Attributes.Add("onclick", script);
                    Panel pnlRbtnSet = e.Item.FindControl("pnlSelect") as Panel;
                    pnlRbtnSet.Controls.Add(rdoBtn);
                }
                else 
                {
                    CheckBox chkBox = new CheckBox();
                    chkBox.ID = "chkBxID";
                    chkBox.Checked = true;
                    chkBox.EnableViewState = true;
                    Panel pnlChkBoxesSet = e.Item.FindControl("pnlSelect") as Panel;
                    pnlChkBoxesSet.Controls.Add(chkBox);
                }
            }
        }
    }
