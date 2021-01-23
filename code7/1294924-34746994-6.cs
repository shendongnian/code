    public interface IMySharedService
    {
        void AddData( object newData );
        object GetData();
        event System.Action<object> DataArrived;
    }
