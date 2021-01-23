    var baseQuery = _dbContext.Answers.AsNoTracking()
					.Where(p => p.Location.Company.Id == id
								&& p.Question.Type == QuestionType.Text
								&& p.Text != null
								&& p.Text != "")
					.GroupBy(g => new { Session = g.Session, Location = g.Location.Name })
					.Select(x =>
								new
								{
									Session = x.Key.Session,
									LocationName = x.Key.Location,
									LastAnswer = x.OrderByDescending(f => f.DateCreated).FirstOrDefault()
								})
					.Select(x => new GetLastCommentsByCountByCompanyIdDTO
					{
						LocationName = x.LocationName,
						DateCreated = x.LastAnswer.DateCreated,
						Comment = x.LastAnswer.Text
					})
					.OrderByDescending(x => x.DateCreated)
					.Take(count);
                var res = baseQuery.ToList();
