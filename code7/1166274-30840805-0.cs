    public void CreateUserDefinedTable(string tableName)
    {
        string connectionString = "Give your Connection String";
        string sqlQuery = "select c.name as COLUMN_NAME, t.name as TYPE_NAME,c.max_length as MAX_LENGTH " +
                            "from sys.columns c, sys.types t " +
                            "where c.object_id = (select type_table_object_id from sys.table_types where name = '"+tableName+"') " +
                            "and t.user_type_id = c.user_type_id " +
                            "order by c.column_id ";
        string data = "", type = "";
        DataTable processedTable = new DataTable();
        DataColumn newcolumn = new DataColumn();
        DataSet ds = new DataSet();
        SqlConnection conObj = new SqlConnection(connectionString);
        SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                switch (ds.Tables[0].Rows[i]["TYPE_NAME"].ToString())
                {
                    case "varchar":
                        newcolumn = processedTable.Columns.Add(ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString(), typeof(string));
                        newcolumn.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[i]["MAX_LENGTH"].ToString());
                        break;
                    case "nvarchar":
                        newcolumn = processedTable.Columns.Add(ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString(), typeof(string));
                        newcolumn.MaxLength = Convert.ToInt32(ds.Tables[0].Rows[i]["MAX_LENGTH"].ToString());
                        break;
                    case "char":
                        newcolumn= processedTable.Columns.Add(ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString(), typeof(char));
                        break;
                    case "int":
                        newcolumn = processedTable.Columns.Add(ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString(), typeof(int));
                        break;
                    case "float":
                        newcolumn = processedTable.Columns.Add(ds.Tables[0].Rows[i]["COLUMN_NAME"].ToString(), typeof(float));
                        break;
                }
            }
        }
    }
