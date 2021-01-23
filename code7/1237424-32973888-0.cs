                DataTable dtData = new DataTable("DATA");
                Dictionary<string, List<double>> collection1 = dtData.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Name"), y => y.Field<double>("Value"))
                    .ToDictionary(x => x.Key, y => y.ToList());
                Dictionary<string, double> collection2 = dtData.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Name"), y => y.Field<double>("Value"))
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
    ​
