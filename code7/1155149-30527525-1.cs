    var v1 = db.Votes.Add(new Vote { VoteYear = "2001", });
    				var v2 = db.Votes.Add(new Vote { VoteYear = "2001", });
    				var v3 = db.Votes.Add(new Vote { VoteYear = "2002", });
    				var v4 = db.Votes.Add(new Vote { VoteYear = "2003", });
    
    				v1.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, };
    				v1.VoteInfo.Add(new VoteInfo { VoterId = "2", });
    				v3.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, };
    
    				db.SaveChanges();
    
    				var votesOf1In2001 = db.Votes
    					.Where(x => 
    						x.VoteYear == "2001" && 
    						x.VoteInfo.Any(x2 => x2.VoterId == "1"))
    					.ToList();
