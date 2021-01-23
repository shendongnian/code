        //  In class VNode
        private bool _isSelected = false;
        public bool IsSelected {
            get { return _isSelected; }
            set {
                _isSelected = value;
                OnPropertyChanged("IsSelected");
                // Elided: much boilerplate checking for redundancy, null parent, etc.
                if (IsSelected)
                    Parent.SelectedVNodes.Add(this);
                else
                    Parent.SelectedVNodes.Remove(this);
             }
         }
