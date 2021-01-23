        private ICommand selectionChanged;
        public ICommand SelectionChanged
        {
            get { return selectionChanged; }
            set { SetProperty(ref selectionChanged, value); }
        }
