            //Connection String to Excel Workbook
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            var Builder = new StringBuilder("INSERT INTO poi (num_route, pk) select num_route,pk_debut VALUES ");
            bool first = true;
            using (var conn = new OleDbConnection(connString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                using (var cmd = new OleDbCommand("SELECT num_route,pk_debut,pk_fin FROM [Sheet1$]", conn))
                using (var da = cmd.ExecuteReader())
                {
                    while (da.Read())
                    {
                        if (!first) Builder.Append(",");
                        Builder.Append("(");
                        Console.WriteLine(da[0]);
                        Builder.Append(",");
                        Console.WriteLine(da[1]);
                        Builder.Append(",");
                        Console.WriteLine(da[2]);
                        Builder.Append(")");
                        first = false;
                    }
                }
            }
            using (NpgsqlConnection cnx = new NpgsqlConnection("Server=localhost;Port=5432;User Id=postgres;Password=*****;Database=****;"))
            {
                cnx.Open();
                var quer = Builder.ToString();
                using (NpgsqlCommand cm = new NpgsqlCommand(quer, cnx))
                    cm.ExecuteNonQuery();
            }
