               DataTable dt = new DataTable();
                dt.Columns.Add("ParentID", typeof(int));
                dt.Rows.Add(new object[] {5978});
                dt.Rows.Add(new object[] {5978});
                dt.Rows.Add(new object[] {5978});
                dt.Rows.Add(new object[] {5978});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5979});
                dt.Rows.Add(new object[] {5980});
                dt.Rows.Add(new object[] {5980});
                dt.Rows.Add(new object[] {5980});
                dt.Rows.Add(new object[] {5980});
                dt.Rows.Add(new object[] {5981});
                dt.Rows.Add(new object[] {5981});
                dt.Rows.Add(new object[] {5981});
                var results = dt.AsEnumerable()
                    .GroupBy(x => x.Field<int>("ParentID"))
                    .Select(x => new { ParentID = x.Key, Count = x.Count() })
                    .ToList();
    ​
