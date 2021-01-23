    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var dataItem = (UserInteractionList)e.Row.DataItem;
        string images = dataItem.Image;
        string[] strArray = images.Split('|');
        
        for (int i = 0; i < strArray.Length; i++)
        {
            Image photoImageField = new Image();
            photoImageField.ImageUrl = strArray[i];
            e.Row.Cells[2].Controls.Add(photoImageField);
        }
    }
