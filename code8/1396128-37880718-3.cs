    public ICommand RemoveCommand => new DelegateCommand<object>(OnRemoveCommand);
    
            private void OnRemoveCommand(object obj)
            {
                myCriteriaViewCollection.Remove(obj as CriteriaView);
            }
