    protected void rptMonthlyFiles_ItemCreated(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            //there are one of these for each month cut the rest out to make smaller code sample
            //Below gets DB info and sets up user control properly for UI based on business rules
            ((NRTWebApplication.UserControls.ucMonthlyFile2)e.Item.FindControl("ucOctMonthlyFile")).GetFileInfo();
    
            // This is how I am adding the event handler for each user control and it does not work like if done in Page_Load
            ((NRTWebApplication.UserControls.ucMonthlyFile2)e.Item.FindControl("ucOctMonthlyFile")).UserControlUploadButtonClicked += new EventHandler(ManageUploader);
        }
    }
