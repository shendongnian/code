         protected void lvSelectedVoucher_ItemDeleting(object sender, ListViewDeleteEventArgs e)
            {
     if (e.CommandName == "Delete")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
    
                    int listcount = lvSelectedVoucher.Items.Count;
    
                    if (listcount  == index+1)
                    {
                        DataTable curTable = (DataTable)ViewState["SelectedVoucher"];
                        curTable.Rows[index].Delete();
                        ViewState.Add("SelectedVoucher", curTable);
                        lvSelectedVoucher.DataSource = null;
                        lvSelectedVoucher.DataSource = curTable;
                        lvSelectedVoucher.DataBind();
                        UpdatePanel1.Update();
                    }
        }
