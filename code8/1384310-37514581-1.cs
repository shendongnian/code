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
            select grp)
             .AsEnumerable()
             .Select(x=>new {
                 x.Key.DispatchDate,
                 x.Key.TypeDetails,
                 x.Key.PackNo,
                 x.Key.Thickness,
                 x.Key.Width,
                 x.Key.Length,
                 x.Key.Sheets,
                 CBM = ((int.Parse(x.Key.Length)) * (int.Parse(x.Key.Length))).ToString(),
       })
       .ToList();
