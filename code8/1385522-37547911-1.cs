    dynamic bookdata = JsonConvert.DeserializeObject(bookdata_);
    dynamic boy = orderbookdata.asks;
    double[][] e = ((IEnumerable<dynamic>)boy)
                    .Select(b => (IEnumerable<dynamic>)b)
                                 .Cast<double>()
                                 .ToArray())
                    .ToArray();
