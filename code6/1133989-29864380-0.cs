    protected void Add_Click(object sender, EventArgs e)
    {
        //Get the reference of the clicked button.
        LinkButton button = (sender as LinkButton );
     
        //Get the command argument
        string cat_id = button.CommandArgument;
        // Type cast to int if application and use it.
    }
