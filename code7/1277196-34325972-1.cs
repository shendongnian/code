    public IMvxCommand AddPlayerCommand
        {
            get
            {
                return new MvxCommand(() => _parent.ExecuteAddPlayerCommand(new PlayerViewModelWrapper(RowItem, _parent, _listType, _messenger)));
            }
        }
