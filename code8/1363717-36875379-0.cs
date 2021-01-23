    public async Task<ICollection<TicketDto>> GetAllUnansweredTicketsAsync()
    {
        return (await _context.Tickets.Include(m => m.Message)
            .Include(u=>u.User)
            .OrderByDescending(d=>d.Message.Date)
            .ToListAsync())
            .Select(t => new TicketDto(t))
            .ToList();
    }
