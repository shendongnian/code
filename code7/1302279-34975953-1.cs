    @{
	    var usernameAttrs = new Dictionary<string, object>
	                        	{
	                        		{"class ", "form-control"},
	                        		{"placeholder  ", "Enter your username"},
	                        		{"required", true},
	                        	};
	    if (String.IsNullOrEmpty(this.Model.UserName))
        {
            usernameAttrs.Add("autofocus", true);
        }
    }
