    public class UserData
    {
        #region Declarations
        private string _theEnteredData;
        private string _theRandomData;
        public UserData()
        {
        }
        public UserData(string theEnteredData, string theRandomData)
        {
            this._theEnteredData = theEnteredData;
            this._theRandomData = theRandomData; 
        }
        #endregion
        #region Properties
        public string theEnteredData
        {
            get { return _theEnteredData; }
            set { _theEnteredData = value; }
        }
        public string theRandomData
        {
            get { return _theRandomData; }
            set { _theRandomData = value; }
        }
        #endregion
    }
