    public class MultiListWrapper : List<object[]>
    {
        private Type[] fieldTypes;
        public MultiListWrapper(int length, params object[] fields)
        {
            fieldTypes = fields.Select(f => f.GetType()).ToArray();
            for (int r = 0; r < length; r++)
            {
                var row = new object[fields.Length];
                for (int f = 0; f < fields.Length; f++)
                {
                    var field = fields[f];
                    row[f] = (field as Array).GetValue(r);
                }
                Add(row);
            }
        }
    }
