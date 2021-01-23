     void AddNewRecordRowToGrid()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        if (ViewState["PurchaseDetails"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["PurchaseDetails"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //Creating new row and assigning values  
                    drCurrentRow = dtCurrentTable.NewRow();
                    dtCurrentTable.Rows[i - 1]["Name"] = Name.Text;
                    dtCurrentTable.Rows[i - 1]["Quantity"] = Convert.ToInt32(Quantity.Text);
                    dtCurrentTable.Rows[i - 1]["Price"] = Convert.ToDecimal(Price.Text);
                    //drCurrentRow["Price"] = Convert.ToDecimal(Price.Text);
                }
                //Removing initial blank row  
                if (dtCurrentTable.Rows[0][0].ToString() == "")
                {
                    dtCurrentTable.Rows[0].Delete();
                    dtCurrentTable.AcceptChanges();
                }
                //Added New Record to the DataTable  
                dtCurrentTable.Rows.Add(drCurrentRow);
                //storing DataTable to ViewState  
                ViewState["PurchaseDetails"] = dtCurrentTable;
                //binding Gridview with New Row  
                GridView1.DataSource = dtCurrentTable;
                GridView1.DataBind();
            }
        }
    }
