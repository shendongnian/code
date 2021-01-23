    protected void em_contact_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection myConnection = new SqlConnection(ConnectionString);
        myConnection.Open();      
         
        ListView parent = (ListView)sender;
        
        if(parent != null)
           var contact_nameTextBox = (TextBox)(parent.FindName("contact_nameTextBox"));
        string contact_Name = contact_nameTextBox.Text;
       //Your code
    }
