	var query =
		messages
			.GroupBy(x => x.ContextId)
			.Select(xs =>
				xs
					.Publish(ys =>
						ys
							.Where(y => y.Topic == "A")
							.Select(y =>
								ys
									.Where(w => w.Topic == "B")
									.TakeUntil(ys.Where(w => w.Topic != "B")))
							.Switch()))
			.Merge();
