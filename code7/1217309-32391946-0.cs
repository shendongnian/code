    public class PlayerData
    {
        private bool _isAlive;
        public bool isAlive
        {
            get { return _isAlive;}
            set { _isAlive = value;}
        }
    
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    
        public PlayerData()
        {
            _isAlive = false;
            _Name = "";
        }
    
        public void SetisAlive(bool a)
        {
            _isAlive = a;
        }
    }
