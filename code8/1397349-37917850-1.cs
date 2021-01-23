     List<MyResult> result = new List<MyResult>();
     MyResult r1 = new MyResult
     {
         Category = "Student",
         Name = "Micheal",
         Score1 = 7.5f,
         Score2 = 9.5f,
         Score3 = 6.5f
     };
     result.Add(r1);
     DataTable dt = new DataTable();
     dt.Columns.Add("Category");
     dt.Columns.Add("Name");
     dt.Columns.Add("Score1");
     dt.Columns.Add("Score2");
     dt.Columns.Add("Score3");
     foreach (MyResult item in result)
     {
         DataRow row = dt.NewRow();
         row["Category"] = item.Category;
         row["Name"] = item.Name;
         row["Score1"] = item.Score1;
         row["Score2"] = item.Score2;
         row["Score3"] = item.Score3;
         dt.Rows.Add(row);
     }
