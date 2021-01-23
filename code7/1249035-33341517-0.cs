    public interface IValue<T> { T GetValue(); }
    public class SomeClass : IValue<DbDataReader>, IValue<SqlDataReader>
    {
        DbDataReader IValue<DbDataReader>.GetValue() { return objDbDataReader; }
        SqlDataReader IValue<SqlDataReader>.GetValue() { return objSqlDataReader; }
    }
