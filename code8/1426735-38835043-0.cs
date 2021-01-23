    var result = Ds1.Tables["dtSubVariant"].AsEnumerable()
                 .GroupBy(i => i.Type)
                 .select(x=>new
                       {
                        Type= i.Key.Type,
                        SubVariantList=i.Select(x=>x.SubvariantName).ToArray()
                       }).ToList();
