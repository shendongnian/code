     static class Extensions
    {
        public static void AddDataObject(this List<DATA> dataList, params string[] values)
        {
            dataList.Add(new DATA() { Name = values[0], Value = values[1] });
        }
    }
