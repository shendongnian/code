    if ( is_logged_on ) { // previously run initiator.start() and listen for initiator.IsLoggedOn to be true
    	Console.WriteLine("We're logged on!");
    	Console.WriteLine("Sending QuoteRequest...");
    
    	// we're using two sessions: 1 for quotes and another for trades
    	// QuoteSessionID holds sessionID for quote operations
    	if ( application != null ) {
    	
    		// generate a unique request ID
    		string qrid = new Random().Next(111111111, 999999999).ToString();
    		QuickFix.Fields.QuoteReqID QuoteReqID = new QuickFix.Fields.QuoteReqID(qrid);
    		
    		// create QuoteRequest instance
    		QuickFix.FIX44.QuoteRequest message = new QuickFix.FIX44.QuoteRequest(QuoteReqID);
    
    		// Symbol, OrderQty and Account are in a repeating groups
    		QuickFix.Group group = new QuickFix.Group(QuickFix.Fields.Tags.NoRelatedSym, QuickFix.Fields.Tags.Symbol);
    		group.SetField(new QuickFix.Fields.Symbol("EURUSD"));
    		group.SetField(new QuickFix.Fields.OrderQty(500));
    		group.SetField(new QuickFix.Fields.Account(Account));
    		
    		// add this group to message
    		message.AddGroup(group);
    		
    		// send message to FIX server with QuoteSessionID
    		QuickFix.Session.SendToTarget(message, application.QuoteSessionID);
    
    	}
    	else
    	{
    		Console.WriteLine("QuoteSessionID is null");
    	}
    }
