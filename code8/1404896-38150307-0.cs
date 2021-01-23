            DataTable dt = new DataTable();
            dt.Columns.Add("LotNo", typeof(int));
            dt.Columns.Add("Level", typeof(int));
            dt.Columns.Add("IsValid", typeof(string));
            dt.Rows.Add(123, 2, "Yes");
            dt.Rows.Add(123, 2, "Yes");
            dt.Rows.Add(123, 2, "Yes");
            dt.Rows.Add(123, 3, "Yes");
            dt.Rows.Add(123, 3, "No");
            dt.Rows.Add(123, 3, "Yes");
            dt.Rows.Add(456, 2, "Yes");
            dt.Rows.Add(456, 2, "No");
            dt.Rows.Add(456, 2, "No");
            dt.Rows.Add(456, 2, "No");
            dt.Rows.Add(456, 3, "Yes");
            dt.Rows.Add(890, 1, "No");
            dt.Rows.Add(890, 1, "No");
            var stat = dt.AsEnumerable()
                .GroupBy(g => new
                {
                    LotNo = g.Field<int>("LotNo"),
                    Level = g.Field<int>("Level"),
                    IsValid = g.Field<string>("IsValid")
                })
                .Select(s => new
                {
                    LotNo = s.Key.LotNo,
                    Level = s.Key.Level,
                    IsValid = s.Key.IsValid,
                    Count = s.Count()
                });
