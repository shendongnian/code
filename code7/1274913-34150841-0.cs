    using (var context = new DragonLairContext())
    {
        Tournament tournament = context.Tournaments 
                .Include(a => a.Game)
                .Include(g => g.Game.Genre)
                .Include(b => b.Groups.Select(g => g.Teams))
                .Include(c => c.TournamentType)
                .FirstOrDefault(d => d.Id == id);
        return tournament;               
    }
