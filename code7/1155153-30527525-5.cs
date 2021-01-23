				var v1 = db.Votes.Add(new Vote { VoteYear = "2001", });
				var v2 = db.Votes.Add(new Vote { VoteYear = "2001", });
				var v3 = db.Votes.Add(new Vote { VoteYear = "2002", });
				var v4 = db.Votes.Add(new Vote { VoteYear = "2003", });
				v1.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, new VoteInfo { VoterId = "3", }, }; 
				v2.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "1", }, new VoteInfo { VoterId = "4", }, }; 
				v3.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "2", }, }; 
				//v1.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "3", }, }; 
				//v2.VoteInfo = new List<VoteInfo> { new VoteInfo { VoterId = "4", }, };
				db.SaveChanges();
				// Each record corresponds to a vote in 2001 where voter #1 has voted.
				// VoteInfo for each voter in this vote is included.
				var votesIn2001With1 = db.Votes
					.Where(x1 => 
						x1.VoteYear == "2001" &&
						x1.VoteInfo.Any(x2 => x2.VoterId == "1"))
					.Select(x => new {
						vote = x,
						voteInfo = x.VoteInfo.ToList(),
					})
					.ToList();
				// Each record corresponds to a vote in 2001 where voter #1 has voted.
				// VoteInfo only for voter #1 is included.
				var votesOf1In2001 = db.Votes
					.Where(x1 => 
						x1.VoteYear == "2001" &&
						x1.VoteInfo.Any(x2 => x2.VoterId == "1"))
					.Select(x1 => new {
						vote = x1,
						voteInfo = x1.VoteInfo
							.Where(x2 => x2.VoterId == "1")
							.ToList(),
					})
					.ToList();
