        public class TableData : MonoBehaviour
        {
            public string[] tableKey;
            public string[] tableType;
            public DataTable dt = new DataTable();
            public TableData()
            {
                dt.Columns.Add("Key", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Entry", typeof(string));
            }
            public TableData(string[] _tableKey, string[] _tableType, string[] entries)
            {
                for (int i = 0; i < _tableKey.Length; i++)
                {
                    dt.Rows.Add(new object[] { _tableKey[i], _tableType[i], entries[i] });
                }
     
            }
        }
    ​
