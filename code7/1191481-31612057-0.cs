    class ExtendedPing : Ping
    {
        public delegate void ExtendedPing_Completed(object sender, PingCompletedEventArgs e, int identifier);
        public event ExtendedPing_Completed On_ExtendedPing_Completed;
        private int _i = 0;
        public ExtendedPing(int i)
        {
            _i = i;
            base.PingCompleted += ExtendedPing_PingCompleted;
        }
        void ExtendedPing_PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (On_ExtendedPing_Completed != null) 
            {
                On_ExtendedPing_Completed(sender, e, _i);
            }
        }
    }
