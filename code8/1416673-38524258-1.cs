	var lines = Lines.Where(i => 
					i.Tools.Any(t => 
								t.Tasks.Any(y => 
										y.SchedItems.Any(u => 
													u.SchedDate >= StartDateQuery  && 
													s.SchedDate <= EndDateQuery 
													) 
											)
									)
				   );
	lines.Foreach(i => new 
					{
						i.Tools = i.Tools.Where(t => 
													t.Tasks.Any(y => 
															y.SchedItems.Any(u => 
																		u.SchedDate >= StartDateQuery  && 
																		s.SchedDate <= EndDateQuery 
																		) 
																)
											);
						i.Tools.Foreach(t => new
						{
							t.Tasks = t.Tasks.Where(y => 
														y.SchedItems.Any(u => 
																	u.SchedDate >= StartDateQuery  && 
																	s.SchedDate <= EndDateQuery 
																	) 
												    );
						});
					}
	             );
