    public static DataTable create_DataTable_From_Generic_Class(Type t)
        {
            DataTable d = new DataTable();
            FieldInfo[] fI = t.GetFields();
            for(int i = 0; i < fI.Length; i++)
            {
                DataColumn dC = new DataColumn(fI[i].Name, fI[i].FieldType);
                d.Columns.Add(dC);
            }
            return d;
        }
        public static object[] Create_Datatable_Row_From_Generic_Class(Type t, object instance,DataTable dt)
        {
           
            FieldInfo[] f = t.GetFields();
            object[] ret = new object[f.Length];
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ret[i] = t.GetField(dt.Columns[i].ColumnName).GetValue(instance);
            }
            return ret;
        }
        public static List<string[]> getParams(Type type, bool convertToSQL)
        {
            
            List<string[]> ret = new List<string[]>();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach (FieldInfo prop in type.GetFields())
                properties.Add(prop.Name, prop.FieldType);
            foreach (string key in properties.Keys)
            {
                string[] r = { key, properties[key].ToString().Replace("System.", "") };
                ret.Add(r);
            }
            if (convertToSQL)
            {
                return convertFromNetToSQLDataTypes(ret);
            }
            else
            {
                return ret;
            }
        }
        private static List<string[]> convertFromNetToSQLDataTypes(List<string[]> list)
        {
            foreach (string[] data in list)
            {
                data[1] = data[1].Replace("Int16", "tinyint");
                data[1] = data[1].Replace("Int32", "int");
                data[1] = data[1].Replace("Int64", "bigint");
                data[1] = data[1].Replace("Double", "float");
                data[1] = data[1].Replace("Boolean", "tinyint");
                data[1] = data[1].Replace("Double", "float");
                data[1] = data[1].Replace("Long", "bigint");
                data[1] = data[1].Replace("String", "varchar(100)");
            }
            return list;
        }
        public static object[] sql_Reader_To_Type(Type t, SqlDataReader r)
        {
            List<object> ret = new List<object>();
            while (r.Read())
            {
                FieldInfo[] f = t.GetFields();
                object o = Activator.CreateInstance(t);
                for (int i = 0; i < f.Length; i++)
                {
                    string thisType = f[i].FieldType.ToString();
                    switch (thisType)
                    {
                        case "System.String":
                            f[i].SetValue(o, Convert.ToString(r[f[i].Name]));
                            break;
                        case "System.Int16":
                            f[i].SetValue(o, Convert.ToInt16(r[f[i].Name]));
                            break;
                        case "System.Int32":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]));
                            break;
                        case "System.Int64":
                            f[i].SetValue(o, Convert.ToInt64(r[f[i].Name]));
                            break;
                        case "System.Double":
                           // Console.WriteLine("converting " + f[i].Name + " to double");
                            double th;
                            if (r[f[i].Name] == null)
                            {
                                th = 0;
                            }
                            else
                            {
                                if (r[f[i].Name].GetType() == typeof(DBNull))
                                {
                                    th = 0;
                                }
                                else
                                {
                                    th = Convert.ToDouble(r[f[i].Name]);
                                }
                            }
                            try { f[i].SetValue(o, th); }
                            catch (Exception e1)
                            {
                                throw new Exception("can't convert " + f[i].Name + " to doube - value =" + th);
                            }
                            break;
                        case "System.Boolean":
                            f[i].SetValue(o, Convert.ToInt32(r[f[i].Name]) == 1 ? true : false);
                            break;
                        case "System.DateTime":
                            f[i].SetValue(o, Convert.ToDateTime(r[f[i].Name]));
                            break;
                        default:
                            throw new Exception("Missed data type in sql select in getClassMembers class line 73");
                    }
                }
                ret.Add(o);
            }
            return ret.ToArray();
        }
 
