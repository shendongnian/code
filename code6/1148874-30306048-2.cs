    public static void SerializePerinatalModel<T>(IDictionary<string, object> dataModel, T perinatalModel, int perinatalReportID)
        {
            Type sourceType = typeof(T);
            foreach (PropertyInfo propInfo in (sourceType.GetProperties()))
            {
                if (dataModel.ContainsKey(propInfo.Name))
