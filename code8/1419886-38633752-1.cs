    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.IsInEditMode) 
        {
            GridEditableItem editItem = (GridEditableItem)e.Item;
            RadComboBox combo = (RadComboBox)editItem.FindControl("updateComboBox"); 
            combo.DataBind(); 
            combo.SelectedValue = DataBinder.Eval(editItem.DataItem,"ID").ToString();
        }
    }
