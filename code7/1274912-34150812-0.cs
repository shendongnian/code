      Tournament tournament = context.Tournaments
                .Include(a => a.Game)
                .Include(g => g.Game.Genre)
                .Include(b => b.Groups)
                .Include(c => c.TournamentType).ToList()
                .FirstOrDefault(d => d.Id == id);
