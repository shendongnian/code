    public IQueryable<TEntity> GetByFilter(
        ColumnAndValue byWhere = null,
        string byWhereString = null,
        string byOrder = null,
        string byDir = null
        );
    
    public class ColumnAndValue {
        public String Column { get; private set; }
        public String Value { get; private set; }
    
        public ColumnAndValue(string column, string value) {
            Column = column;
            Value = value;
        }
    }
