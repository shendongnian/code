    Protected Void GridViewName_ItemCommand(Object sender, DataGridCommandEventArgs e)
    {
    if(e.CommandName=="")
        {
        LinkButton lnkButton=(LinkButton)e.CommandSource
        lnkButton.ForeColor = System.Drawing.Color.Red;
        //Do any additional operation if needed on link button click
        }
    }
