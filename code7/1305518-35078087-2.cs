    int maxLength = 100;
    string body = DT1["UserBody"].ToString();
    
    if (!string.IsNullOrEmpty(body))
    {
    	if(body.length > maxLength)
    	{
    		body.Length = body.Substring(0, maxLength);
    		// if you want to have full words
    		while(body.Substring(body.length-2, body.length-1) != " ")
    		{
    			body = body.Substring(0, body.length-2);
    		}
    		lblAboutMe.Text = body + "...";
    	}
    	else
    	{
    		lblAboutMe.Text = body;
    	}
    }
