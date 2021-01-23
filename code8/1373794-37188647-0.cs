    public interface ISqlType
    {
        string getHeader();
    }
    public class SqlProc
    {
        public string getHeader()
        {
            return "I'm a SqlProc!"
        }
    }
    public class SqlFunction
    {
        public string getHeader()
        {
            return "I'm a SqlFunction!"
        }
    }
    public class SqlView
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
