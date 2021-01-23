    public interface IDataView
    {
        Visibility Visibility { get; }
    }
    
    public class DataView : IDataView
    {
        public Visibility Visibility { get; set; }
    }
    
    public class PrivateDataView : IDataView
    {
        public Visibility Visibility
        {
            get { return Visibility.Private; }
        }
    }
