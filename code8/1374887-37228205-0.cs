                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                var results =
                    from c1 in dt1.AsEnumerable()
                    join c2 in dt2.AsEnumerable()
                       on c1.Field<int>("ID") equals c2.Field<int>("ID") into cs
                    select new { Category = c1.Field<string>("ColB"), Fields = cs }; 
