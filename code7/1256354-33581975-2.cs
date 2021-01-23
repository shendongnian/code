	var result = myTargetType.SubCategories
							 .Select(sc => new Tuple<int, IEnumerable<SubTargetType>>
												(sc.Id, 
												 sc.SubTargetTypes.Where(stt => stt.Name.ToLower().Contains(type.ToLower()))))
							 .SelectMany(tpl => tpl.Item2.Select(stt => new SubTargetResponse {
											Id = stt.Id,
											CategoryId = tpl.Item1,
											Name = stt.Name }));
