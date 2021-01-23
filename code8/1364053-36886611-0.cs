    public class XController 
    {
        public XController(IIndex<String, IDatabaseHelper> databaseHelpers) 
        {
            this._databaseHelpers = databaseHelpers; 
        }
        private readonly IIndex<String, IDatabaseHelper> _databaseHelpers;
        
        public void Do()
        {
            IDatabaseHelper oledb = this._databaseHelpers["Oledb"];
        }
    }
