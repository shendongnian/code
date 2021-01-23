    public class PipeService : IPipeService
    {
        public static string URI
           = "net.pipe://localhost/Pipe";
        // This is when we used the HTTP bindings.
        // = "http://localhost:8000/Pipe";
        #region IPipeService Members
        public void PipeIn(int data)
        {
            if (DataReady != null)
                DataReady(data);
        }
        public delegate void DataIsReady(int hotData);
        public DataIsReady DataReady = null;
        #endregion
    }
