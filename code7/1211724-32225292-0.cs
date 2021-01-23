    public class IndirectClass
    {
        private FormClass _form;
        public IndirectClass(FormClass form)
        {
            _form = form;
        }
        
        public FormClass
        {
            get { return _form; }
        }
    }
