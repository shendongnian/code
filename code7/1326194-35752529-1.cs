	public interface IDataSource<out T, in T1>
	{
		IEnumerable<T> GetAllRows();
		List<Object> GetValues(T1 row); 
	}
	public abstract class DataSource<T, T1> : IDataSource<T, T1>
	{
		public abstract IEnumerable<T> GetAllRows();
		public abstract List<Object> GetValues(T1 row); 
	}
	public class XlsxDataSource : DataSource<Row, Row>, IDataSource<Row, Row>
	{
		public abstract IEnumerable<Row> GetAllRows();
		public abstract List<Object> GetValues(Row row); 
	}
	
	public class DerivedRow : Row {}
	
