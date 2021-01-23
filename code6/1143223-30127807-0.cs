    class Main
    {
        private exLog exLog;
        public Main()
        {
        }
        public void ExLog()
        {
            exLog = new exLog();
        }
        public void ExLog(String where)
        {
            exLog = new exLog(where);
        }
        public void ExLog(String where, String message)
        {
            exLog = new exLog(where, message);
        }
    }
