    void Student_OnItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ...
        PlaceHolder phRecords = e.Item.FindControl("phRecords") as PlaceHolder;
        ImageButton imgButton = new ImageButton();
        // Set the ImageButton properties here
        ph.Controls.Add(imgButton);
    }
