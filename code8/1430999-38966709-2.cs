	var result = FinalList.SelectMany(item => new List<dynamic>
							{
								new { Date = item.Birthday.ToString("ddMM"), Event = "Birthday", Item = item },
								new { Date = item.Anniversary.ToString("ddMM"), Event = "Anniversary", Item = item }
							})
						  .GroupBy(item => new { item.Date, item.Event })
						  .Select(grouping => new { Date = grouping.Key, Events = grouping.ToList() }).ToList();
