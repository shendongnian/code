                Dictionary<Tuple<string,string,string>,List<DataRow>>  myDict1 = dt.AsEnumerable()
                    .GroupBy(x => new Tuple<string, string, string>(x.Field<string>("Col A"), x.Field<string>("Col A"), x.Field<string>("Col A")), y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
               //if only one value per key then use this
                Dictionary<Tuple<string, string, string>, DataRow> myDict2 = dt.AsEnumerable()
                    .GroupBy(x => new Tuple<string, string, string>(x.Field<string>("Col A"), x.Field<string>("Col A"), x.Field<string>("Col A")), y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());​
