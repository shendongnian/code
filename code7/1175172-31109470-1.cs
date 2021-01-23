        private string myText;
        public string MyText { 
            get {
                return myText;
        }
            set {
                myText = value;
                RaisePropertyChanged("MyText");
            }
        }
   
