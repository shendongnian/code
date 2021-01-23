    public void getWord()
    {
        manageWords mngit = new manageWords(this);     // pass local checkSpell
        speakIt spk = new speakIt();
        do
        {
            string word = mngit.readFile();     // pass local checkSpell
            // etc
    class manageWords // Check file, open and edit it
    {
        public int lineNumber;
        private checkSpell ckt;
        public manageWords(checkSpell)
        {
            ckt = checkSpell;
        }
        //Check if file exists
        public string readFile()
        {
            // etc
