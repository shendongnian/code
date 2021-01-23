     private void PopulateContactMethod(int intContactMethodID)
        {
        DataTable dt = new DataTable();
                dt = "get Your data from db";
                
                cboContact.DataSource = dt;
                cboContact.DataTextField = dt.Columns["field to view"].ToString();
                cboContact.DataValueField = dt.Columns["id of field to view"].ToString();
                cboContact.DataBind();
                ListItem li1 = new ListItem("--Select Contact Method--", "0");
                cboContact.Items.Insert(0, li1);
        }
