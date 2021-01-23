        private ObservableCollection<Block> _blocks;
        public ObservableCollection<Block> Blocks
        {
            get
            {
                return _blocks;
            }
            set
            {
                _blocks = value;
                if (_blocks != null)
                {
                    foreach (var block in _blocks)
                    {
                        block.PropertyChanged += block_PropertyChanged;
                    }
                }
                NotifyPropertyChanged("Blocks");
            }
        }
       // The event handler for PropertyChanged 
        private void block_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "Status" || StatusChanged == null)
            {
                return;
            }
            var block = sender as Block;
            if (block != null)
            {
                StatusChanged.Invoke(block, new StatusChangedHandlerArgs(block.Status));
            }
        }
