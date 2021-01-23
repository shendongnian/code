    RelayCommand<string> _ItemDoubleClick;
        public ICommand ItemDoubleClick
        {
            get
            {
                if (_ItemDoubleClick == null)
                {
                    _ItemDoubleClick = new RelayCommand<string>(this.ItemDoubleClickExecuted,
                        param => this.ItemDoubleClickCanExecute());
                }
                return _ItemDoubleClick;
            }
        }
        private bool ItemDoubleClickCanExecute()
        {
            return true;
        }
        private void ItemDoubleClickExecuted(string item)
        {
            //In item you've got the text of double clicked ListViewItem
        }
