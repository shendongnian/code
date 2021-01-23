    <telerik:RadGrid ID="rgItems" 
       ... 
       OnItemCommand="REMOVE THIS EVENT"
       OnInsertCommand="rgItems_InsertCommand"
       OnUpdateCommand="rgItems_UpdateCommand"           
       OnDeleteCommand="rgItems_DeleteCommand">
       <MasterTableView CommandItemDisplay="Top" DataKeyNames="Id"> 
         Make sure Id is the unique Id in your database - normally primary key.
    </telerik:RadGrid>
    
    protected void rgItems_InsertCommand(object source, GridCommandEventArgs e)
    {
       var item = e.Item as GridEditFormItem;
       var txtClass= item.FindControl("txtClass") as TextBox;
       // Insert to database - Do not need to call rgItems.Rebind(); here.
    }
    
    protected void rgItems_UpdateCommand(object source, GridCommandEventArgs e)
    {
       var item = e.Item as GridEditFormItem;    
       int id = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);   
       var txtClass= item.FindControl("txtClass") as TextBox;    
       // Update - Do not need to call rgItems.Rebind(); here.
    }
    
    protected void rgItems_DeleteCommand(object source, GridCommandEventArgs e)
    {
       int id = Convert.ToInt32(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["Id"]);     
       // Delete - Do not need to call rgItems.Rebind(); here.
    }
