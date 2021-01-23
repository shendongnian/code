	xs
		.Select(x =>
			Observable
				.Start(() =>
				{
					if (x == 0)
						throw new NotSupportedException();
					else
						return x;
				})
				.Materialize())
		.Merge()
		.Where(x => x.Kind != NotificationKind.OnCompleted)
		.Subscribe(
			x => Console.WriteLine(String.Format(
				"{0} {1}",
				x.Kind,
				x.HasValue ? x.Value.ToString() : "")),
			ex => Console.WriteLine(ex.ToString()));
