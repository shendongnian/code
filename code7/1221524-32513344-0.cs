    protected void RadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string listName = ((RadioButtonList)sender).ID
        // listName = RadioButtonList1 or RadioButtonList2 or whatever the ID is set to.
            
        if (listName == "RadioButtonList1")
        {
            // Rest of your code goes here, now that you know which RadioButtonList the event was fired from
        }
    }
