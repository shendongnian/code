    class MyCm : ChangeMonitor
    {
        string uniqueId = Guid.NewGuid().ToString();
        public MyCm()
        {
            InitializationComplete();
        }
        protected override void Dispose(bool disposing) { }
        public override string UniqueId
        {
            get { return uniqueId; }
        }
        public void Stuff()
        {
            this.OnChanged(null);
        }
    }
