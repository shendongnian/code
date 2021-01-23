    //Are there any rows
    if(Reader.HasRows)
    {
    	//If so read them
    	while (Reader.Read())
    	{
    		if (Reader[5].ToString() == "manager")
    		{
    			this.Hide();
    			Student_Info stuInf = new Student_Info();
    			stuInf.Show();
    			break;
    		}
    		else if (Reader[5].ToString() == "employee")
    		{
    			MessageBox.Show("log in as a employee ");
    		}
    	}
    }
    else
    {
    	MessageBox.Show("Inviled User name or password");
    }
