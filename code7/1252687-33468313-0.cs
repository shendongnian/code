    protected void em_contact_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        myConnection.Open();      
         
       
        var children = AllChildren(sender);
        var contactName = children.OfType<TextBox>().First(x => x.Name.Equals("contact_nameTextBox"));
        string contact_Name = contact_nameTextBox.Text;
       //Your code
    }
