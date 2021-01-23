	var sortedHistos = new List<HistoMesure>();
	var filteredHistos = sortedHistos
		.GroupBy(h => h.Commentaires)
		.Select(h => new HistoMesure
		{
			Debut = h.Min(g => g.Debut),
			Fin = h.Max(g => g.Debut),
			Commentaires = h.Key
		});
