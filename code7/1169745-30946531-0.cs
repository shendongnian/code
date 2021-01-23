     [WebMethod]
    public static List<ReportData> GetData(int id)
    {
        var dt = GetData(id);
        if (dt == null) return dt;
        var reportElements = dt.ToObjectList<ReportData>();
        //var json = dt.Serialize() ?? "";
        return reportElements;
    }
    public class ReportData
    {
        public int Id { get; set; }
        public string ActivityCode { get; set; }
        public string Duration { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public static List<T> ToObjectList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            var list = new List<T>();
            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        continue;
                    }
                }
                list.Add(obj);
            }
            return list;
        }
        catch
        {
            return null;
        }
    }
