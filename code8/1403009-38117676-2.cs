        private bool expanded;
        public bool Expanded
        {
            get { return expanded; }
            set
            {
                if (expanded != value)
                {
                    expanded = value;
                    NotifyOfPropertyChange(() => VirtualizedViewModel);
                    NotifyOfPropertyChange(() => Expanded);
                }
            }
        }
        
        public MyViewModel VirtualizedViewModel
        {
            get
            {
                if (Expanded)
                {
                    return this;
                }
                else
                {
                    return null;
                }
            }
        }
