        public class MyTable
        {
            public string ColumnName { get; set; }
        }
        
        await GetAllAsync<MyTable>();
