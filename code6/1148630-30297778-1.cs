    public static List<ExpressionListDictionary> MyMethod(int weeknr)
            {
                using (DataAccessAdapter adapter = CreateAdapter())
                {
                    LinqMetaData meta = new LinqMetaData(adapter);
                    var q = (from i in meta.Test
                             where i.startDate != null && WeekOf(i.StartDate.tostring()) == weeknr
                             select new ExpressionListDictionary()
                                 {                                 
                                    {"SomeId", i.Id}
                                 }
                    );
                    return q.ToList();
                }
            }
