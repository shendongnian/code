        public async Task<ParticipantTournament> GetParticipantTournamentByDescending(int tournamentId, int participantId)
        {
            var lastMatchId = await _dbRepositories.TournamentParticipantMatchRepository
                .Where(x => x.TournamentId == tournamentId)
                .OrderByDescending(y => y.TournamentMatch.RoundNumber)
                .ThenByDescending(y => y.TournamentMatch.Id)
                .Select(x => x.Id).FirstOrDefaultAsync();
            
             var response = await _dbRepositories.TournamentParticipantMatchRepository
                .Where(x => x.TournamentId == tournamentId)
                .Where(x => (x.Participant1Id == participantId || x.Participant2Id == participantId))
                .Include(x => x.Tournament)
                .Include(x => x.Participant1)
                .Include(x => x.Participant2)
                .Include(x => x.TournamentMatch)
                .ToListAsync();
                
               var logic = response.Select(z=> new TournamentParticipantMatchLogicDto
                {
                    IsLastMatch = z.Id == lastMatchId,
                    TournamentParticipantMatch = z
                })
                ;
            return new ParticipantTournament
            {
                ParticipantMatches = logic,
            };
            
        }
