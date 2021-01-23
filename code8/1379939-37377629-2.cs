    public class ComplexFunctionality
    {
        private readonly Control _c;
        public ComplexFunctionality(Control c)
        {
            _c = c;
        }
        public void SettingGuid(Guid newGuid)
        {
            ...
        }
    }
    public class MyTextBox : TextBox
    {
        private readonly ComplexFunctionality _cs = new ComplexFunctionality(this);
        private Guid _guid;
        public Guid Guid {
            get { return _guid; }
            private  set { 
                _cs.SettingGuid(value);
                _guid = value;
            }
        }
    }
