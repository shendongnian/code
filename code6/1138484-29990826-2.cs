    public partial class MyControl : UserControl
    {
        private readonly static WeakReference<MyControl> _instance
            = new WeakReference<T>(null);
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
