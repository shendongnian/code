	Lines.Where(i => 
					i.Tools.Any(t => 
							t.Tasks.Any(y => 
									y.SchedItems.Any(u => 
												u.SchedDate >= StartDateQuery  && 
												u.SchedDate <= EndDateQuery 
												) 
										)
								)
			   );
