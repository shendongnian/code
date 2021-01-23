     public async Task<ParticipantTournament> GetParticipantTournamentByDescending(int tournamentId, int participantId)
            {
                var response = await _dbRepositories.TournamentParticipantMatchRepository
                    .Where(x => x.TournamentId == tournamentId)
                    .OrderByDescending(y => y.TournamentMatch.RoundNumber)
                    .ThenByDescending(y => y.TournamentMatch.Id)
                    .Include(x => x.Tournament)
                    .Include(x => x.Participant1)
                    .Include(x => x.Participant2)
                    .Include(x => x.TournamentMatch)
                    .ToListAsync();
                    
                   var logic = response.Select(z => new TournamentParticipantMatchLogicDto
                    {
                        IsLastMatch = response.Select(x => x.TournamentMatchId).First() == z.TournamentMatchId,
                        TournamentParticipantMatch = z
                    })
                    ;
                return new ParticipantTournament
                {
                    ParticipantMatches = logic.Where(x => (x.TournamentParticipantMatch.Participant1Id == participantId || x.TournamentParticipantMatch.Participant2Id == participantId)),
                };
    
                
            }
