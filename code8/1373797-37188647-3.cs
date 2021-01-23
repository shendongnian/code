    public interface ISqlType
    {
        string getHeader();
    }
    public class SqlProc : ISqlType
    {
        public string getHeader()
        {
            return "I'm a SqlProc!"
        }
    }
    public class SqlFunction : ISqlType
    {
        public string getHeader()
        {
            return "I'm a SqlFunction!"
        }
    }
    public class SqlView : ISqlType
    {
        public string getHeader()
        {
            return "I'm a SqlView!"
        }
    }
    ISqlType objSqlType;
    switch (type)
    {
        case ObjectType.PROC:
            objSqlType = new SqlProc();
            break;
        case ObjectType.FUNCTION:
            objSqlType = new SqlFunction();
            break;
        case ObjectType.VIEW:
            objSqlType = new SqlView();
            break;
        default:
            break;
    }
    string header = objSqlType.getHeader();
