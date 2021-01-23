        public string note
        {
            get
            {
                string _note = fullnote;
                if (!String.IsNullOrEmpty(_note))
                {
                    if (_note.Length > 250)
                    {
                        _note = _note.Substring(0, 250);
                    }
                }
                return _note;
            }
            set { }
        }
