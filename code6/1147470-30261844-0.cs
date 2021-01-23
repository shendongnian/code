    public class MyModel
    {
        private string _prop;
        public string Prop
        {
            get
            {
                return !string.IsNullOrEmpty(_prop) ? _prop.Trim() : this._prop;
            }
            set
            {
                this._prop = value.Trim();
            }
        }
    }
