    public abstract class SqlCommandParameter
    {
        public string ParameterName { get; private set; }
        public SqlDbType SqlDbType { get; private set; }
        protected SqlCommandParameters(string parameterName, SqlDbType sqlDbType)
        {
            ParameterName = parameterName;
            SqlDbType = sqlDbType;
        }
    }
    public class SqlCommandParameter<T>: SqlCommandParameter
    {
        public T SqlDbValue { get; private set; }
        public SqlCommandParameter(string parameterName, SqlDbType sqlDbType, T sqlDbValue): base(parameterName, sqlDbType)
        {
            SqlDbValue = sqlDbValue;
        }
    }
