    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //Is it a GridDataItem
        if (e.Item is GridDataItem)
        {
            //Get the instance of the right type
            GridDataItem dataBoundItem = e.Item as GridDataItem;
    
            //Check the formatting condition
            if (dataBoundItem["ExpiryDate"].Text =="1/1/1900")
            {
               dataBoundItem["ExpiryDate"].Text="";
                //Customize more if needed...
            }
        }
    }
