    public class ValueEventArgs : EventArgs
    {
        private string _smth;
        public ValueEventArgs(string smth)
        {
            this._smth = smth;
        }  
        public string Someth_property
        {
            get { return _smth; }
        }     
    }
    
