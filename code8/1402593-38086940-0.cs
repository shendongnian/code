	List<NGram> grams = new List<NGram>()
	{
		new NGram() { Probability = 0.5 },
		new NGram() { Probability = 0.35 },
		new NGram() { Probability = 0.15 }
	};
	
	var rnd = new Random();
	
	var result =
		grams
			.Aggregate(
				new { sum = 0.0, target = rnd.NextDouble(), gram = (NGram)null },
				(a, g) =>
					a.gram == null && a.sum + g.Probability >= a.target
						? new { sum = a.sum + g.Probability, a.target, gram = g }
						: new { sum = a.sum + g.Probability, a.target, a.gram });
