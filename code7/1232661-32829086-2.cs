	var territories = new Dictionary<int, AllSalesTerritory>()
	_connection.Query<AllSalesTerritory, MySalesPerson, AllSalesTerritory>
		(query, (pd, pp) =>
		{
			AllSalesTerritory territory;
			if(!territories.TryGetValue(pd.TerritoryId, out territory))
			{
				territories.Add(pd.TerritoryId, territory = pd);
			}		
			
			territory.SalesPersons.Add(pp);
			return territory;
		}, splitOn: "BusinessEntityId");
					
	List<AllSalesTerritory> allSalesTerrotories = territories.Values.ToList();
