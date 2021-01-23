    public partial class MyControl : UserControl
    {
        private static WeakReference<MyControl> _instance;
        public static MyControl Instance
        {
            get
            {
                UserControl result;
                if(!_instance.TryGetTarget(out result))
                    _instance.SetTarget(result = new MyControl());
                return result;
            }
        }
    }
