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
                if (ret[i] == null)
                {
                    ret[i] = "null";
                }
            }
            return ret;
        }
