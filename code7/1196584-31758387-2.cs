    class Parser
    {
        private BetterParser bp = new BetterParser();
        private FileStream fs;
        private boolean successful;
    
        public void ReadFile(string file)
        {
            fs = GetStream(file);
        }
    
        public void Parse()
        {
            successful = bp.ParseIt(fs);
        }
    
        public boolean IsValid()
        {
            return successful;
        }
    }
