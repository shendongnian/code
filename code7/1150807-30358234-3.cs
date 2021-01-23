        public ICollection<MatchGame> FindByAwayTeam(Team awayTeam)
        {
            return matchGames
                .Where(mg => mg.AwayTeam.Id == awayTeam.Id)
                .ToList();
        }
