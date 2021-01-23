    public class Class1 : IMyInterface
    {
        public event Action<IMyInterface, string> TextChanged;
        protected void RaiseTextChanged(string newValue)
        {
            var handler = TextChanged;
            if (handler != null)
                handler(this, newValue);
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; RaiseTextChanged(value); }
        }
    }
