    Class Something something
    {
        public int Distance
        {
        private set
         {
           _distance = value;
         }
        get
         {
           return _distance;
         }
        }
    
    // Keep this at the end of the class
    // In visual studio you can collapse region and wont attract
    // attention/distracting in your editor.
    #region data members
    private int _distance;
    #endregion data members
    }
