        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList1.DataSourceID = "LinqDataSource1";
            DropDownList1.DataTextField = "localidad";
            DropDownList1.DataValueField = "basededatos";
            for (int i = 0; i < DropDownList1.Items.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(DropDownList1.Items[i].Value))
                {
                    DropDownList1.Items.Remove(DropDownList1.Items[i]);
                    i--;
                }
            }
        }
