    public class MySingleton {
        private static MySingleton instance_ = null;
        
        private Timer timer_;
        public static GetInstance(){
            if (instance_ == null) instance_ = new MySingleton();
            return instance_;
        }
        private MySingleton(){
             timer_ = new Timer(Callback, ...);
        }
    }
