        string _content;
        public Value_Type()
        {
            this._editor = editor;
            this._displayName = displayName;
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        [Editor(typeof(TEditor), typeof(UITypeEditor))]
        public IRecord Key { get; set; }
    }
