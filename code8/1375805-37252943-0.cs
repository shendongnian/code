    foreach (Publication publication in publications)
    {
    	var total = prenumerators.Where(o => o.PublicationCode == publication.PublicationCode)
    							 .Sum(o => o.Count * publication.MonthPrice);
    	publication.Earnings += total;
    }
