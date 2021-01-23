     query = from record in context.tables
                    group record by new
                    {
                        record.Col3,
                        record.Col4,
                        record.Col5,
                    } into g
                    select new QueryResult
                    {
                        Col1 = g.Sum(x => x.Col1),
                        Col2 = g.Sum(x => x.Col2),
                        Col3 = g.Key.Col3,
                        Col4 = g.Key.Col4,
                        Col5 = g.Key.Col5,
                        col6 = g.Count()
    
                    };
