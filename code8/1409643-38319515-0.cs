    var temp = from e in _dbRepositories.TournamentParticipantMatchRepository
               where (from f in _dbRepositories.TournamentParticipantMatchRepository
                      where f.TournamentId == tournamentId)
                       .Include(x => x.Tournament)
                .Include(x => x.Participant1)
                .Include(x => x.Participant2)
                .Include(x => x.TournamentMatch)
                .Select(z => new TournamentParticipantMatchLogicDto
                {
    
    
                    IsLastMatch = false, // <==== Problem here,
                    TournamentParticipantMatch = z
    
    
                }).Where(x => (x.TournamentParticipantMatch.Participant1Id == participantId || x.TournamentParticipantMatch.Participant2Id == participantId))
                .ToListAsync();
    
     int maxResult= temp.Max(t => t.TournamentParticipantMatch.Id);
    var update= temp.SingleOrDefault(x => x.TournamentParticipantMatch.Id== maxResult);
    if(update!= null)
        update.IsLastMatch= true;
