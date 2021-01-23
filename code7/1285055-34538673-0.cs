    var queryResults = session.Advanced.DocumentQuery<Continent>()
    					.OpenSubClause()
    						.WhereEquals("Countries,Provinces,Cities.Name", "Aloma")
    						.AndAlso()
    						.WhereEquals("Countries,Provinces,Cities.Address", "123")
    					.CloseSubClause()
    					.AndAlso()
    					.OpenSubClause()
    						.WhereEquals("Countries,Provinces,Cities.Name", "Hemane")
    						.AndAlso()
    						.WhereEquals("Countries,Provinces,Cities.Address", "Hemane")
    					.CloseSubClause()
    					.ToList();
    					
