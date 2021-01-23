    this.GlobalRequestFilters.Add((req, resp, dto) =>
    {
        if (dto is KendoQueryBase)
        {
            KendoQueryBase qb = dto as KendoQueryBase;
            if (qb.Sort == null) qb.Sort = new List<SortTerm>();
            Dictionary<string, string> qs = req.QueryString.ToDictionary();
            var i = 0;
            while (qs.ContainsKey("sort[{0}][field]".Fmt(i)))
            {
                qb.Sort.Add(new SortTerm()
                {
                    field = qs["sort[{0}][field]".Fmt(i)],
                    dir = qs["sort[{0}][dir]".Fmt(i)]
                });
                i++;
            }
        }
    });
