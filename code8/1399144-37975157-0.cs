    // Create message instance
    // If you create a specific FIX Message new QuickFix.FIX44.MarketDataRequest() instead of new Message()
    // you don't need set the MessageType and your intelisense is better.
    QuickFix.FIX44.MarketDataRequest msg = new QuickFix.FIX44.MarketDataRequest();
    
    // Fill message fields
    msg.SetField(new MDReqID("PrimoApp123")); 
    msg.SetField(new SubscriptionRequestType('1')); 
    msg.SetField(new MarketDepth(0)); 
    msg.SetField(new MDUpdateType(0)); 
    
    // Add the MDEntryTypes group
    QuickFix.FIX44.MarketDataRequest.NoMDEntryTypes noMDEntryTypes = new QuickFix.FIX44.MarketDataRequest.NoMDEntryTypes();
    noMDEntryTypes.SetField(new MDEntryType('0')); 
    msg.addGroup(noMDEntryTypes);
    
    // Add the NoRelatedSym group
    QuickFix.FIX44.MarketDataRequest.NoRelatedSym noRelatedSym = new QuickFix.FIX44.MarketDataRequest.NoRelatedSym();
    noRelatedSym.setSymbol("GBPUSD");
    msg.addGroup(noRelatedSym);
    
    // Send message
    Session.SendToTarget(msg, FeederApp.mysession);
