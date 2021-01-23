                DataTable dt = new DataTable();
                dt.Columns.Add("Index", typeof(int));
                dt.Rows.Add(new object[]{1});
                dt.Rows.Add(new object[]{2});
                dt.Rows.Add(new object[]{3});
                dt.Rows.Add(new object[]{4});
                dt.Rows.Add(new object[]{5});
                dt.Rows.Add(new object[]{6});
                dt.Rows.Add(new object[]{7});
                dt.Rows.Add(new object[]{8});
                dt.Rows.Add(new object[]{9});
                dt.Rows.Add(new object[]{10});
                dt.Rows.Add(new object[]{11});
                dt.Rows.Add(new object[]{12});
                dt.Rows.Add(new object[]{13});
                dt.Rows.Add(new object[]{14});
                dt.Rows.Add(new object[]{15});
                dt.Rows.Add(new object[]{16});
                var results = dt.AsEnumerable()
                    .Select((x,i) => new {index = i, row = x})
                    .GroupBy(y => (int)(y.index/5))
                    .Select(z => z.Select(a => a.row).ToList()).ToList();
