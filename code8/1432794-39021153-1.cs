    public class DbParamList : List<IDbDataParameter>
    {
        private DbParamList() {}
        public static DbParamList Make(IEnumerable<SqlParameter> parms)
        {
            var prmLst = new DbParamList();
            prmLst.AddRange(parms);
            return prmLst;
        }
        public static DbParamList Make(params SqlParameter[] parms)
        {
            var prmLst = new DbParamList();
            prmLst.AddRange(parms);
            return prmLst;
        }
        public void AddSQLParm(string parmName, bool value)
        { Add(new SqlParameter(parmName, value ? "1" : "0")); }
        public void AddSQLParm(string parmName, bool? value)
        {
            if (!value.HasValue)
            {
                throw new ArgumentNullException(
                    "Null value passed to AddSQLParm<>()");
            }
            Add(new SqlParameter(parmName, value.Value ? "1" : "0"));
        } 
        public void AddSQLParm<T>(string parmName, T value)
        {
            var type = typeof(T);
            if (type.IsEnum) Add(new SqlParameter(parmName, 
                Convert.ChangeType(value, Enum.GetUnderlyingType(type))));
                
            else Add(new SqlParameter(parmName, value));
        } 
        public void AddSQLParm<T>(string parmName, T? value,
            bool ignoreNull = false) where T : struct
        {
            var type = typeof(T);
            if (!value.HasValue)
            {
                if (ignoreNull) return;
                throw new ArgumentNullException(
                    "Null value passed to AddSQLParm<>()");
            }
            // ---------------------------------------
            if (type.IsEnum) Add(new SqlParameter(parmName, 
                Convert.ChangeType(value.Value, Enum.GetUnderlyingType(type))));
            else Add(new SqlParameter(parmName, value.Value));
        }
        public void AddSQLTableParm<T>(string parmName, IEnumerable<T> values)
        {
            var parm = new SqlParameter(parmName, CreateDataTable(values))
            {
                SqlDbType = SqlDbType.Structured,
                TypeName = "dbo.keyIds"
            };
            Add(parm);
        }
        internal static DataTable CreateDataTable<T>(IEnumerable<T> values)
        {
            var dt = new DataTable();
            var props = typeof (T).GetProperties();
            if (props.Length > 0)
            {
                foreach (var col in props)
                    dt.Columns.Add(col.Name, col.PropertyType);
                foreach (var id in values)
                {
                    var newRow = dt.NewRow();
                    foreach (var prop in id.GetType().GetProperties())
                        newRow[prop.Name] = prop.GetValue(id, null);
                    dt.Rows.Add(newRow);
                }
            }
            else
            {
                dt.Columns.Add("ids");
                foreach (var id in values) dt.Rows.Add(id);
            }
            return dt;
        }
    }
