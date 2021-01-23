                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Agent", typeof(string));
                dt1.Columns.Add("Product1", typeof(int));
                dt1.Columns.Add("Product2", typeof(int));
                dt1.Rows.Add(new object[] {"A", 1, 3});
                dt1.Rows.Add(new object[] {"B", 4, 5});
                dt1.Rows.Add(new object[] {"A", 5, 4});
                DataTable dt2 =  dt1.Clone();
                var sum = dt1.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Agent"))
                    .Select(m => new
                    {
                        key = m.Key,
                        p1 = m.Sum(s => s.Field<int>("Product1")),
                        p2 = m.Sum(s => s.Field<int>("Product2"))
                    }).ToList();
                foreach (var row in sum)
                {
                    dt2.Rows.Add(new object[] { row.key, row.p1, row.p2 });
                }
                dataGridView1.DataSource = dt2;
