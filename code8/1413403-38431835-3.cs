    from p in _db.places
    join v in _db.VoteLogs
    //This is how you join by multiple values
    on new { Id = p.Id, UserID = userId } equals new { Id = v.PlaceId, UserID = v.UserID } 
    into jointData
    //This is how you actually turn the join into a left-join
    from jointRecord in jointData.DefaultIfEmpty()
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
    	UserVoted = v.Vote 
        /* The row above will fail if there is no record due to the left join. Do one of these:
           UserVoted = v?.Vote - will give the default behavior for the type of Uservoted
           UserVoted = jointRecord == null ? string.Empty : v.Vote */
    }
