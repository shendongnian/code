    var grouped = (from p in _researchArticleRepository.GetResearchArticles().ToList()
                       group p by new { month = p.DatePublished.Month, year = p.DatePublished.Year } into d
                       select new
                       {
                           dt = d.Key.month + "-" + d.Key.year,
                           dtByMonthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(d.Key.month) + " " + d.Key.year
                       }//count = d.Count() }
                       )
                       .OrderByDescending(g => g.dt);
        return grouped.ToDictionary(item => item.dt, item => item.dtByMonthName);
