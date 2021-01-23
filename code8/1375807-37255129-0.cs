    publications.ForEach(publication =>
        {
            publication.Earnings = prenumerators
                             .Where(o => o.PublicationCode == publication.PublicationCode)
                             .Sum(o => o.Count * publication.MonthPrice);
        });
