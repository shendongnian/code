    class Parser
    {
        private BetterParser bp = new BetterParser();
        private FileStream fs;
        private boolean successful;
    
        public Parser(string file)
        {
            fs = GetStream(file);
        }
    
        public void Parse()
        {
            successful = bp.ParseHtml(fs);
        }
    
        public boolean IsValid()
        {
            return successful;
        }
    }
