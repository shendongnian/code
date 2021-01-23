    namespace FieldStrikeMove.PortableData.Helpers
    {
        [Table("Table1")]
        public class GenericSqliteObject : Object
        {
            public GenericSqliteObject()
            {
    
            }
    
            private string _column1;
            [Column("Column1")]
            public string Column1
            {
                get { return _column1; }
                set { _column1 = value; }
            }
    
    
            private string _column2;
            [Column("Column2")]
            public string Column2
            {
                get { return _column2; }
                set { _column2 = value; }
            }
    
    
            public int? GetInt(string column)
            {
                int rint;
    
                if (Int32.TryParse(column, out rint))
                    return rint;
                else
                    return null;
            }
    
            public long? GetLong(string column)
            {
                long rlong;
    
                if (Int64.TryParse(column, out rlong))
                    return rlong;
                else
                    return null;
            }
    
            public bool? GetBool(string column)
            {
                bool rbool;
    
                if (Boolean.TryParse(column, out rbool))
                    return rbool;
                else
                    return null;
            }
            public double? GetDouble(string column)
            {
                double rdouble;
    
                if (Double.TryParse(column, out rdouble))
                    return rdouble;
                else
                    return null;
            }
            public float? GetFloat(string column)
            {
                float rfloat;
    
                if (float.TryParse(column, out rfloat))
                    return rfloat;
                else
                    return null;
            }
        }
    }
