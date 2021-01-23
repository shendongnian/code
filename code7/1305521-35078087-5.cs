    int maxLength = 100;
    string body = DT1["UserBody"] != null ? DT1["UserBody"].ToString() : "";
    
    if (!string.IsNullOrEmpty(body))
    {
    	if(body.Length > maxLength)
    	{
    		body = body.Substring(0, maxLength);
    		// if you want to have full words
            if (body.Contains(" "))
            {
                while (body[body.Length - 1] != " ")
                {
                    body = body.Substring(0, body.Length - 2);
                    if(body.Length == 1)
                    {
                        break;
                    }
                }
            }
    		lblAboutMe.Text = body + "...";
    	}
    	else
    	{
    		lblAboutMe.Text = body;
    	}
    }
