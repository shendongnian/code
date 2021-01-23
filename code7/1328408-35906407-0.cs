     var dt1 = new DataTable();
            dt1.Columns.Add("emp_num", typeof(int));
            dt1.Columns.Add("salary", typeof(int));
            dt1.Columns.Add("ov", typeof(double));
            dt1.Columns[0].Unique = true;
            dt1.Rows.Add(455, 3000, 67.891);
            dt1.Rows.Add(677, 6000, 50.113);
            dt1.Rows.Add(778, 5500, 12.650);
            dt1.Rows.Add(779, 5500, 12.672);
            var dt2 = new DataTable();
            dt2.Columns.Add("emp_num", typeof(int));
            dt2.Columns.Add("salary", typeof(int));
            dt2.Columns.Add("ov", typeof(double));
            dt2.Columns[0].Unique = true;
            dt2.Rows.Add(455, 3000, 67.891);
            dt2.Rows.Add(677, 5000, 50.113);
            dt2.Rows.Add(778, 5500, 12.672);
            dt2.Rows.Add(779, 5500, 12.672);
            var dtListValues1 = new List<List<string>>();
  
            for (int j = 0; j < dt2.Rows.Count; j++)
            {
                var list = new List<string>();
                for (var i = 0; i < dt2.Columns.Count; i++)
                {                
                   
                        list.Add(dt2.Rows[j][i].ToString());
                    list.Add("===");
                        list.Add(dt1.Rows[j][i].ToString());
                    list.Add("||");
                    if(dt2.Rows[j][i].ToString() == dt1.Rows[j][i].ToString())
                    {
                        list.Add("true");
                    }
                    else
                    {
                        list.Add("false");
                    }
                }
                dtListValues1.Add(list);
            }
            var rowsWithDifferentCells = dtListValues1.Where(x => x.Contains("false"));
            
            foreach (var item in dtListValues1)
            {
                Console.WriteLine("Row-->> "+ string.Join(",",item));
            }
            Console.WriteLine("----------------------------------------");
            foreach (var item in rowsWithDifferentCells)
            {
                Console.WriteLine("Row with different cell-->> "+string.Join(",", item));
            }
