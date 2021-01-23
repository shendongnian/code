    int maxLength = 100;
    string body = DT1["UserBody"] != null ? DT1["UserBody"].ToString() : "";
    
    if (!string.IsNullOrEmpty(body))
    {
    	if(body.Length > maxLength)
    	{
    		body = body.Substring(0, maxLength);
    		// if you want to have full words
    		while(body.Substring(body.Length-2, body.Length-1) != " ")
    		{
    			body = body.Substring(0, body.Length-2);
    		}
    		lblAboutMe.Text = body + "...";
    	}
    	else
    	{
    		lblAboutMe.Text = body;
    	}
    }
