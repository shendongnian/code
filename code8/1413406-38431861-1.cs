    var result = 
        (from p in _db.Places
        join v in _db.VoteLogs
        on new { p.Id, userId } equals new { v.PlaceId, v.UserId } into LEFTJOIN
        from result in LEFTJOIN.DefaultIfEmpty()
        where p.Public == 1
        select new
        {
            Id = p.Id,
            UserId = p.UserId,
            X = p.X,
            Y = p.Y,
            Titlu = p.Titlu,
            Descriere = p.Descriere,
            Public = p.Public,
            Votes = p.Votes,
            DateCreated = p.DateCreated,
            DateOccured = p.DateOccured,
            UserVoted = result == null ? null /* replace with your value */ : x.Vote
        }).AsQueryable();
    
    return result;
