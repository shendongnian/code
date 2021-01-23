    public IEnumerable<Table1> Method1()
        {
            string StrSql = "Select * From [Table1] Where [Name] in (";
            List<string> par = fav.Split(',').ToList();
            foreach (string _par in par)
            {
                StrSql += _par;
                if (_par != par.Last())
                {
                    StrSql += ',';
                }
                else
                {
                    StrSql += ")";
                }
            }
            return conn.Query<Table1>(StrSql);
        }
