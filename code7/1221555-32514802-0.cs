      public List<FDetails> GetReocrds(DateTime date)
                {
                    var fs = from f in DBContext.RecordsTable
                    where f.Date > date 
                    && ConvertToIntfun(f.Time.Split(':')[0]) >= date.Hour 
                    && ConvertToIntfun(f.Time.Split(':')[1])>date.Minute
                                    select new FDetails(f.Id,f.Info, (DateTime)f.Date, f.Time);
                    return fs.ToList();
                }
                internal static int ConvertToIntfun(string value)
                {
                    int result = 0;
                    if (int.TryParse(value, out result))
                    {
                        return result;
                    }
                    else
                    {
                        return result;
                    }
                }
