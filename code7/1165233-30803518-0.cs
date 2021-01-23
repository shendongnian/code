    public SelectList GetRoutingActionList()
        {
            Dictionary<string, string> routingActions = new Dictionary<string, string> { 
                                                            { "Approved", "Approve" },
                                                            { "Return To", "Return To .." }, 
                                                            { "Return To Sender", "Return To Sender" }, 
                                                            { "Disapprove", "Disapprove" },
                                                            { "Set On Hold", "Set On Hold" } 
                                                        };
    
            SelectList routingActionList = new SelectList(routingActions, "Key", "Value");
            return routingActionList.Where(x => x.Key != "Disapprove")
                                       .ToList();
    }
