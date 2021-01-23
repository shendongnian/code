        Dictionary<string, Dictionary<string, object>> DataTableToDictionary(DataTable dt, string prefix, string id)
        {
            var cols = dt.Columns.Cast<DataColumn>().Where(c => c.ColumnName != id);
            return dt.Rows.Cast<DataRow>()
                     .ToDictionary(r => prefix + r[id].ToString(),
                                   r => cols.Where(c => !Convert.IsDBNull(r[c.ColumnName])).ToDictionary(c => c.ColumnName, c => r[c.ColumnName]));
        }
