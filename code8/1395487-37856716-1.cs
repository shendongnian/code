    RestResult<Agent> agentResults;
    RestResult<Company> companyResults;
    RestResult<Contact> contactResults;
    RestResult<Ticket> ticketResults;
    
    var t1 = Task.Run(() => agentResults = agentService.GetAll(Epoch))
    var t2 = Task.Run(() => companyResults = companyService.GetAll(Epoch));
    var t3 = Task.Run(() => contactResults = contactService.GetAll(Epoch));
    var t4 = Taks.Run(() => ticketResults = ticketService.GetAll(Epoch));
    
    await Task.WhenAll(t1,t2,t3,t4);
    //results should be filled here
