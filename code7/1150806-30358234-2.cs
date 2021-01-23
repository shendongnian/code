        public ICollection<MatchGame> FindByAwayTeam(Team awayTeam)
        {
            return matchGames
                .AsEnumerable()
                .Where(mg => mg.AwayTeam == awayTeam)
                .ToList();
        }
