    context.Text.AddOrUpdate(
    	new Text[]
    	{
    	  new Text() {
    		Fieldname = "SERVER",
    		Description = "Server", 
    		Language = context.Language.Where(l => l.Code == "AX").FirstOrDefault()
    		}, 
    		//More new Text() here...
    	}
    );
