    public class BlobManager
    {
        static BlobManager _inst;
        public static BlobManager Instance {
        get
        {
            if (_inst == null)
                _inst = new BlobManager();
            return _inst;
        }
        }
        private BlobManager() 
        {
          
        }
    }
