	Dictionary<int, IEnumerable<SpelerData>> queryDict = new Dictionary<int, IEnumerable<SpelerData>>(); //Prepare a dictionary of query
	private void form_load(object sender, EventArgs e) {
		dataGridView2.DataSource = listPlayers.OrderBy(x => x.Achternaam).ToList();
		queryDict.Add(0, listPlayers.OrderBy(x => x.Voornaam));
		queryDict.Add(1, listPlayers.OrderBy(x => x.Achternaam));
		queryDict.Add(2, listPlayers.OrderBy(x => x.Positie));
		queryDict.Add(3, listPlayers.OrderBy(x => x.Nationaliteit));
		queryDict.Add(4, listPlayers.OrderBy(x => x.Age));
		queryDict.Add(5, listPlayers.OrderBy(x => x.Aanval));
		queryDict.Add(6, listPlayers.OrderBy(x => x.Verdediging));
		queryDict.Add(7, listPlayers.OrderBy(x => x.Gemiddeld));
		queryDict.Add(8, listPlayers.OrderBy(x => x.TransferWaarde));
	}
