    Dictionary<string, short> data = dt.AsEnumerable()
                                           .Select(item => new {
                                                                  Key = item.Field<string>("product_name"),
                                                                  Value = item.Field<short>("type_id")
                                                                })
                                            .GroupBy(x=>x.Key)
                                            .Select(x=>x.First())
                                            .ToDictionary(dr => dr.Key, dr => dr.Value, StringComparer.OrdinalIgnoreCase);
