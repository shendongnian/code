      DataTable dt = new DataTable();
                dt.Columns.Add("ABC",typeof(double));
                for (int i = 0; i < 100; i++)
                {
                    Random r = new Random();
                    DataRow dr = dt.NewRow();
                    if (i % 2 != 0)
                    {
                        dr[0] = (double)r.Next(0, 2)/i;
                    }
                    else
                    {
                        dr[0] = 0;
                    }
                    dt.Rows.Add(dr);
                }
                int coutPositiveNumber = dt.AsEnumerable().Count(p => p.Field<double>("ABC")>0);
