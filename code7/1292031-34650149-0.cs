    using System;
    public struct RemarkStruct
    {
    }
    public interface IEventArgs
    {
        RemarkStruct GetRemarkData();
    }
    public class GridViewCommandEventArgs : IEventArgs
    {
        public RemarkStruct GetRemarkData()
        {
            throw new NotImplementedException();
        }
    }
    public class GridViewRowEventArgs : IEventArgs
    {
        public RemarkStruct GetRemarkData()
        {
            throw new NotImplementedException();
        }
    }
