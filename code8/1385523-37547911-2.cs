    dynamic bookdata = JsonConvert.DeserializeObject(bookdata_);
    dynamic boy = orderbookdata.asks;
    Dictionary<double, double> d = ((IEnumerable<dynamic>)boy)
                    .Select(b => (IEnumerable<dynamic>)b)
                                 .Cast<double>())
                    .ToDictionary(i => i.First(), i => i.Last());
