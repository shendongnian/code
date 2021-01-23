          using(SqlConnection c = new SqlConnection("<connectionString>"))
            {
                c.Open();
                DataTable emptyTable = new DataTable();
                emptyTable.Columns.Add("c1", typeof(int));
                emptyTable.Columns.Add("c2", typeof(string));
                DataRow row = emptyTable.NewRow();
                row["c1"] = 99;
                row["c2"] = new String('X', Int16.MaxValue);
               // Uncomment to make table non empty
               // emptyTable.Rows.Add(row);
                SqlCommand cmd = c.CreateCommand();
                if (emptyTable.Rows.Count > 0)
                {
                    cmd.CommandText = "dbo.BOB";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter p = cmd.Parameters.AddWithValue("@TP", emptyTable);
                    p.SqlDbType = SqlDbType.Structured;
                    p.TypeName = "dbo.KrjVarBin";
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "declare @empty as dbo.KrjVarBin; execute dbo.bob @empty";
                }
                cmd.ExecuteNonQuery();
            }
