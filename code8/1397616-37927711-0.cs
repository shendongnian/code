        string searchText = TextBox1.Text;
        var dbResponse = GetDataFromDB(searchText); // This method return data from database
        if(dbResponse != null)
        {
         // set value into grid
        }
        else
        {
        //Error Message or Not Found
        }
