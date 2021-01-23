       private MvxCommand _deleteCommand;
        public IMvxCommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new MvxCommand(() =>
                  WebServiceDeleteStuff(ListItemsToDelete); 
                  RemoveFromListItemsList(ListItemsToDelete);
                  ListItemsToDelete.Clear();
                });
                return _deleteCommand;
            }
        }
