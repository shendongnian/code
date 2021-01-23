    var results = (from a in DeviceList
                    join b in DeviceMaster
                    on a.DeviceMasterId equals b.Id
                    group new { a, b } by new { b.Brand } into grp
                    select new
                    {
                        Brand = grp.Key.Brand,
                        BrandCount = grp.Count(),
                        DeviceCount = grp.Sum(x=> x.a.Qty.GetValueOrDefault())
                    }).ToList();
