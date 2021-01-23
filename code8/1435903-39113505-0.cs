    public static void sql_Reader_To_DataTable_With_Buffer(Type t, SqlDataReader r)
        {
            DataTable dt = create_DataTable_From_Generic_Class(t);
            while (r.Read())
            {
               
                FieldInfo[] f = t.GetFields();
                object[] rowData = new object[dt.Columns.Count];
                for (int i = 0; i < f.Length; i++)
                {
                    string thisType = f[i].FieldType.ToString();
                    switch (thisType)
                    {
                        case "System.String":
                           rowData[i] = Convert.ToString(r[f[i].Name]);
                            break;
                        case "System.Int16":
                           rowData[i] = Convert.ToInt16(r[f[i].Name]);
                            break;
                        case "System.Int32":
                           rowData[i] = Convert.ToInt32(r[f[i].Name]);
                            break;
                        case "System.Int64":
                           rowData[i] = Convert.ToInt64(r[f[i].Name]);
                            break;
                        case "System.Double":
                            // Console.WriteLine("converting " + f[i].Name + " to double");
                            rowData[i] = Convert.ToDouble(r[f[i].Name]);
                            break;
                        case "System.Boolean":
                           rowData[i] = Convert.ToInt32(r[f[i].Name]) == 1 ? true : false;
                            break;
                        case "System.DateTime":
                           rowData[i] = Convert.ToDateTime(r[f[i].Name]);
                            break;
                        default:
                            throw new Exception("Missed data type in sql select in getClassMembers class line 73");
                    }
                }
                dt.Rows.Add(rowData);
                if (dt.Rows.Count == 50000)
                {
                    //process table (dt);
                    dt.Rows.Clear();
                }
            }
            if (dt.Rows.Count > 0)
            {
                //processTable (dt);
               
            }
        }
    com.CommandText = "select top 10000000000000000 * from myHugeTable";
    SqlDataReader = com.ExecuteDataReader();
    sql_Reader_To_DataTable_With_Buffer(typeof(person),read);
