     private string _LabelContent;
        public string LabelContent
        {
            get { return _LabelContent; }
            set
            {
                _LabelContent= value;
                RaisePropertyChangedEvent("LabelContent");
            }
        }
