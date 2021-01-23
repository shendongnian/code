    var v1 = db.Votes.Add(new Vote { VoteYear = "2001", });
    				var v2 = db.Votes.Add(new Vote { VoteYear = "2001", });
    				var v3 = db.Votes.Add(new Vote { VoteYear = "2002", });
    				var v4 = db.Votes.Add(new Vote { VoteYear = "2003", });
    
    				v1.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, }; 
				v2.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "2", }, }; 
				v3.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, };
				db.SaveChanges();
				var votesIn2001 = db.Votes
					.Where(x => x.VoteYear == "2001")
					.Select(x => new {
						vote = x,
						voteInfo = x.VoteInfo.ToList(),
					})
					.ToList();
