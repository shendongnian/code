    public static ModelSingleton Instance
    {
        private static ModelSingleton instance = null;
        private static readonly object syncRoot = new Object();
        private ModelSingleton()
        {
        }
        get
        {
            lock (syncRoot)
            {
                if (instance == null)
                {
                     instance = new ModelSingleton();
                }
            }
        return instance;
        }
    }
