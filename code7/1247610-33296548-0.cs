    DataRow[] dr1 = dtt.Select("Course = 'Math' AND Month > 10");
            var result_one = dr1.AsEnumerable()
                .GroupBy(r => new { Name = r.Field<string>("Name"), Class = r.Field<string>("Class") })
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Class = g.Key.Class,
                    Max = g.Max(r => r.Field<int>("Score")),
                    Max_Month = g.FirstOrDefault(gg => gg.Field<int>("Score") == g.Max(r => r.Field<int>("Score"))).Field<int>("Month"),
                }
                ).Distinct().ToList();
    DataRow[] dr2 = dtt.Select("Course = 'Chem'");
            var result_two = dr2.AsEnumerable()
                .GroupBy(r => new { Name = r.Field<string>("Name"), Class = r.Field<string>("Class") })
                .Select(g => new
                {
                    Name = g.Key.Name,
                    Class = g.Key.Class,                    
                    Chem_Max = g.Max(r => r.Field<int>("Score")),
                    Chem_Max_Month = g.FirstOrDefault(gg => gg.Field<int>("Score") == g.Max(r => r.Field<int>("Score"))).Field<int>("Month"),
                }
                ).Distinct().ToList();
