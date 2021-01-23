    var data = Repository.Query<ProductDestination>()
    	.Where(pd => !pd.Product.IsDeleted)
    	.Select(pd => 
    	new {	
    	   Product = pd.Product,
           Destination = pd.Destination,
    	})
    	.GroupBy(pd => pd.Product)
        //I'm not in a position to test if EF will successfully run the below, so .ToList()
        //May not be required. However, the bulk of the work is done in the database, anyway.
        //.ToList()
        .Select(g => new {
			OfficeId = g.Key.TariffCategory.Office.Id,
			Office = g.Key.TariffCategory.Office.Name,
			Category = g.Key.TariffCategory.Description,
			ArticleId = g.Key.Article.Id,
			Article = g.Key.Article.Title,
			Destinations = g.Select(gg => new { Id = gg.Destination.DestinationId, Name = gg.Destination.Description }),
			GlobalDestinations = g.Key.AllDestinationsInOffice,
			g.Key.Article.LastReviewedDate,
			g.Key.Article.CreatedDate,
			g.Key.Article.CreatedByEmployee
        });
