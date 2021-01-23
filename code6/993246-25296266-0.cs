    public class Parameters : DynamicParameters
    {
        public new void Add(string name, object value = null, DbType? dbType = null, ParameterDirection? direction = null, int? size = null)
        {
            if (dbType == null && value is string)
            {
                if (size == null)
                {
                    dbType = DbType.AnsiString;
                }
                else
                {
                    dbType = DbType.AnsiStringFixedLength;
                }
            }
            base.Add(name, value, dbType, direction, size);
        }
    }
    const string query = @"yourquery"
    Parameters p = new Parameters();
            p.Add("@Tag", tag);
            p.Add("@Start", start);
            p.Add("@End", end);
    var values = c.Query<TagValue>("get_values", p,CommandType.StoredProcedure);
