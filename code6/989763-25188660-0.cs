    public class A : INotifyPropertyChanged
    {
        private B _prop;
        public B Prop
        {
            get { return _prop; }
            set
            {
                if(_prop != null)
                    _prop.words.CollectionChanged -= words_CollectionChanged;
                _prop = value;
                if (_prop != null)
                    _prop.words.CollectionChanged += words_CollectionChanged;
                NotifyPropertyChanged("Prop");
            }
        }
    
        void words_CollectionChanged(object sender, 
                                     NotifyCollectionChangedEventArgs e)
        {
            // Notify other properties here.
        }
    
        public A() { Prop = new B(); }
    
        //Some Property related Prop.words
    
    }
