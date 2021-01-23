                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Descr", typeof(string));
                dt.Columns.Add("IsChecked", typeof(int));
                dt.Rows.Add(new object[] {4,"East", 1});
                dt.Rows.Add(new object[] {1,"Loc Code", 1});
                dt.Rows.Add(new object[] {2,"North", 1});
                dt.Rows.Add(new object[] {3,"South", 0});
                dt.Rows.Add(new object[] {5,"West", 0});
                List<int> StrLocKeys = dt.AsEnumerable().Where(x => x.Field<int>("IsChecked") == 1).Select(y => y.Field<int>("ID")).ToList();​
