    var obj = dt.AsEnumerable()
                .GroupBy(r => r["Head"])
                .ToDictionary(g => g.Key.ToString(),
                              g => g.Select(r => new {
                                                    item = r["Item"].ToString(),
                                                    quantity = (int)r["Quantity"]
                                                 })
                                    .ToArray());
    var json = JsonConvert.SerializeObject(obj);
