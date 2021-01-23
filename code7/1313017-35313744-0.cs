            string Name = "Test1";
            int Id = 1;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("Id",typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1,"Test");
            dt.Rows.Add(1, "Test1");
            DataRow[] r = dt.Select();
            int i = 0; //Not Required.
            while (r.Length>0)
            {
                string toTest = r[i]["Name"].ToString();
                int toTest1 =Convert.ToInt32(r[i]["Id"]);
                if (toTest == Name)
                {
                    Console.WriteLine(toTest);
                }
                if (toTest1 == Id)
                {
                    Console.WriteLine(toTest1);
                }
            }
