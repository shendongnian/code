            SqlConnection conn = new SqlConnection(@"Data Source=SQL2008;Initial Catalog=SMS;User ID=sa;password=sql;");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select *  from P1091", conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            adp.Fill(ds1);
            foreach (RepeaterItem item in rptItemsInCart.Items)
            {
                DropDownList drop = (DropDownList)item.FindControl("DropDownList1");
                drop.DataSource = ds1;
                drop.DataTextField = "P_Dent_N";
                drop.DataValueField = "P_Dent_N";
                drop.DataBind();
                drop.Items.Insert(0, new ListItem("---Select---", "0"));
                    
            }
