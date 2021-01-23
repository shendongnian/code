    public List<Things>MyPrivateList // Only the class its in can touch this
    {
        get { return myPrivateList; }
        private set
        {
           myPrivateList = value;
            coolMethodThatNeedsToRunEverytime();
        }
    }
