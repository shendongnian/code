    public sealed class ClsRegistry
    {
        private static ClsRegistry RegInstance = new ClsRegistry();
        private clsRegistry() { }
        public static ClsRegistry Instance {
            get { return RegInstance; }
        }
        public string DataBase { get; set; }
        public string UserId { get; set; }
        public string PassWord { get; set; }
        public void ReadKeys()
        {
            // ...
        }
    }
