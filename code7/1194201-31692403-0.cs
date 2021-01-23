    public class MyAuth
    {
        private static readonly MyAuth instance = new MyAuth();
        public static MyAuth Instance { get { return instance; } }
        private MyAuth()
        {
            // initialization goes here and will be called once
        }
        // Members. 
    }
