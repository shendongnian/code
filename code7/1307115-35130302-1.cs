            if (!Page.IsPostBack)
            {
                BindDropdwon();
            }
        }
        protected void DropDownListSelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void DropDownListSelectEmployee_TextChanged(object sender, EventArgs e)
        {
        }
        private void BindDropdwon()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            // Here we add three DataRows.
            table.Rows.Add(25, "Indocin");
            table.Rows.Add(50, "Enebrel");
            table.Rows.Add(10, "Hydralazine");
            
            DropDownListSelectEmployee.DataSource = table;
            DropDownListSelectEmployee.DataTextField = "Name";
            DropDownListSelectEmployee.DataValueField = "Id";
            DropDownListSelectEmployee.DataBind();
            ***DropDownListSelectEmployee.Items.Insert(0, new ListItem("--nworks User--", "0"));***
            
        }
    }
