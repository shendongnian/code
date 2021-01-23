    var obj = dt.AsEnumerable()
                .GroupBy(r => r["Head"])
                .Select(g => new
                {
                    Head = g.Key.ToString(),
                    total = g.Sum(x => (int)x["Quantity"]),
                    data = g.Select(r => new
                    {
                        item = r["Item"].ToString(),
                        quantity = (int)r["Quantity"]
                    }).ToArray()
                })
                .ToList();
    var json = JsonConvert.SerializeObject(obj);
