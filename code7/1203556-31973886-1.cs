    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        //Is it a GridDataItem
        if (e.Item is GridDataItem)
        {
            //Get the instance of the right type
            GridDataItem dataBoundItem = e.Item as GridDataItem;
            //Check the formatting condition
            if (dataBoundItem["sample_hour"].Text == "4hr YP")
            {
                SetFormatting(dataBoundItem["ph"], 5.72, 4.75);
                SetFormatting(dataBoundItem["brix"], 22.36, 17.35);
                // etc...
            }
        }
    }
    private void SetFormatting(TableCell cell, float minValue, float maxValue)
    {
        float value = float.Parse(cell.Text);
        
        if (value > minValue || value < maxValue)
        {
            cell.BackColor = Color.Yellow;
            cell.ForeColor = Color.Black;
            cell.Font.Bold = true;
        }
    }
