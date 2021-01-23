	var territories = new Dictionary<int, AllSalesTerritory>()
	var throwAway = _connection.Query<AllSalesTerritory, MySalesPerson, AllSalesTerritory>
					(query, (pd, pp) =>
					{
						AllSalesTerritory territory;
						if(!territories.TryGetValue(pd.ID, out territory))
						{
							territory = pd;
							territories.Add(territory.ID, territory);
						}					
						territory.Add(pp);
						return territory;
					}, splitOn: "BusinessEntityId")
					.ToList();
					
	List<AllSalesTerritory> allSalesTerrotories = territories.Keys.ToList();
