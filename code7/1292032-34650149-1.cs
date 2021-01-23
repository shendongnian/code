    using System;
    public struct RemarkStruct
    {
    }
    public interface IEventArgs
    {
        RemarkStruct GetRemarkData();
    }
    public class GridViewCommandEventArgs : EventArgs, IEventArgs
    {
        public RemarkStruct GetRemarkData()
        {
            throw new NotImplementedException();
        }
    }
    public class GridViewRowEventArgs : EventArgs, IEventArgs
    {
        public RemarkStruct GetRemarkData()
        {
            throw new NotImplementedException();
        }
    }
