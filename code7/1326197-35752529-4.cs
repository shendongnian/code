    public interface IDataSource
    {
        List<object> GetAllRows();
        List<object> GetValues(object row);
    }
    public abstract class DataSource<T> : IDataSource
    {
        public abstract List<T> GetAllRows();
        List<object> IDataSource.GetValues(object row)
        {
            return GetValues((T)row);
        }
        public abstract List<object> GetValues(T row);
        List<object> IDataSource.GetAllRows()
        {
            return GetAllRows().Cast<object>().ToList();
        }
    }
    public class XlsxDataSource : DataSource<Row>
    {
        public override List<object> GetValues(Row row)
        {
            throw new NotImplementedException();
        }
        public override List<Row> GetAllRows()
        {
            throw new NotImplementedException();
        }
    }
