            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1.Columns.Add("ItemCode", typeof(string));
            dt1.Columns.Add("Quantity", typeof(int));
            dt2.Columns.Add("ItemCode", typeof(string));
            dt2.Columns.Add("Quantity", typeof(int));
            dt1.Rows.Add("A", 3000);
            dt1.Rows.Add("B", 5000);
            dt1.Rows.Add("C", 6000);
            dt2.Rows.Add("A", 2000);
            dt2.Rows.Add("A", 1000);
            dt2.Rows.Add("A", 500);
            dt2.Rows.Add("B", 3000);
            dt2.Rows.Add("B", 2000);
            dt2.Rows.Add("c", 6000);
            var query = from row in dt2.AsEnumerable()
                        group row by row.Field<string>("ItemCode") into grp
                        select new
                        {
                            ItemCode = grp.Key,
                            Quantity = grp.Sum(r => r.Field<int>("Quantity"))
                        };
            int i = 0;
            foreach (var item in query)
            {
                if (Convert.ToInt32(item.Quantity) > Convert.ToInt32(dt1.Rows[i]["Quantity"]))
                {
                    Console.WriteLine("Available quantity is "+ dt1.Rows[i]["Quantity"].ToString()+ " for "+item.ItemCode);
                }
                i++;
            }
            Console.Read();
