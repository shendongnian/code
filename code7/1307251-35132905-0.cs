    public static DictionaryWord[] GetDictionaryWords2(int[] categories)
    {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("ID");
                dt.Columns.Add(dc);
                categories.ToList().ForEach(dr => { DataRow d = dt.NewRow(); d[dc] = dr; dt.Rows.Add(d); });
                    cmd.CommandText = "GetDictionaryWords2";
                    var categoriesParams = cmd.Parameters.AddWithValue("@categories", dt);
                    categoriesParams.SqlDbType = SqlDbType.Structured;
                    categoriesParams.TypeName = "dbo.IdList";
                    SqlDataReader r = cmd.ExecuteReader();
    }
