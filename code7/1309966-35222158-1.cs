    private void Click_EventHandler(object sender, ClickedEventArgs e)
    {
        Button filterButton = (Button)sender; //Get the Button which was clicked
        string columnName = filterButton.Tag.ToString();
        //Do Columnspecific filtering as needed:
        if(columnname == "ID")
        {
            //filter your ID-Column here!
        }
    }
