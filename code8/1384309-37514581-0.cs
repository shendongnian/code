     var res = (from packs in data
            where packs.DispatchDate != null || (packs.DispatchDate >= DateTime.Parse(_dateFrom).Date &&
            packs.DispatchDate <= DateTime.Parse(_dateTo).Date)
            orderby packs.Production.DimensionMetric
            group packs by
            new
            {
                 packs.DispatchDate,
                 packs.ProductType.TypeDetails,
                 packs.PackNo,
                 packs.Thickness,
                 Width = packs.Production.DimensionMetric.Substring(0,packs.Production.DimensionMetric.IndexOf('x')),
                 Length = packs.Production.DimensionMetric.Substring(packs.Production.DimensionMetric.IndexOf('x')+1),
                          packs.Sheets,
            }
            into grp
            select new
            {
                 grp.Key.DispatchDate,
                 grp.Key.TypeDetails,
                 grp.Key.PackNo,
                 grp.Key.Thickness,
                 grp.Key.Width,
                 grp.Key.Length,
                 grp.Key.Sheets,
                 //CBM = ((int.Parse(grp.Key.Length)) * (int.Parse(grp.Key.Length))).ToString(),
             }).AsEnumerable()
             .Select(x=>new {
                 x.DispatchDate,
                 x.TypeDetails,
                 x.PackNo,
                 x.Thickness,
                 x.Width,
                 x.Length,
                 x.Sheets,
                 CBM = ((int.Parse(x.Length)) * (int.Parse(x.Length))).ToString(),
       })
       .ToList();
