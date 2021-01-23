    RestResult<Agent> agentResults = null;
    RestResult<Company> companyResults = null;
    RestResult<Contact> contactResults = null;
    RestResult<Ticket> ticketResults = null;
    Parallel.Invoke(
        () => agentResults = agentService.GetAll(Epoch),
        () => companyResults = companyService.GetAll(Epoch),
        () => contactResults = contactService.GetAll(Epoch),
        () => ticketResults = ticketService.GetAll(Epoch)
    );
