    public sealed class ClsRegistry
    {
        private static ClsRegistry RegInstance = new ClsRegistry();
        private clsRegistry() { }
        public static ClsRegistry Instance {
            get { return RegInstance; }
        }
        public string dataBase { get; set; }
        public string userId { get; set; }
        public string passWord { get; set; }
        public void ReadKeys()
        {
            // ...
        }
    }
