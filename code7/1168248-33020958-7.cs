    public void AssignTicketToUser(int teamId, int ticketId)
    {
        var ticket = repository.Get<Ticket>(ticketId);
        var team = repository.Get<Team>(teamId);
        var users = new UserLocator(repository);
        var tickets = new TicketLocator(repository);
        var user = team.GetUserWithLowestLoad(users, tickets);
        user.AssignTicket(ticket);
        repository.Save(user);
    }
