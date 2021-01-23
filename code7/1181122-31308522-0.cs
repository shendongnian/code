    protected void RGGSTAcCode_InsertCommand(object sender, GridCommandEventArgs e)
    {
      GridEditableItem item = e.Item as GridEditableItem;
      DropDownList ddlAccdetail = item.FindControl("ddlAccdetail") as DropDownList;
      
      string Accdetail = ddlAccdetail.SelectedItem.Text;
      string accCode=Accdetail.Split(' ')[0];   //Splitting the string 
      string accDesc=Accdetail.Split(' ')[1];   //with that added empty space
      InsertAccountCode(new Guid(TempGUID.Text), accCode, accDesc);
      BindGrid();
      RGGSTAcCode.Rebind();
    }
