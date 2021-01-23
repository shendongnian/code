    public void AssignTicketToUser(int teamId, int ticketId)
    {
        var ticket = repository.Get<Ticket>(ticketId);
        var team = repository.Get<Team>(teamId);
        var user = team.GetUserWithLowestLoad(repository);
    
        user.AssignTicket(ticket);
        repository.Save(user);
    }
