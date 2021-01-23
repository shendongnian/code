    public class myDataBaseFactory
    {
        private static myDataBase instance = null;
        private static readonly object lockObject = new object();
        public myDataBase Current
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new myDataBase();
                        }
                    }
                }
                return instance;
            }
        }
    }
