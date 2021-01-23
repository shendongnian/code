    //  Add to MainViewModle class
    private VNode _selectedVNode = null;
    public VNode SelectedVNode
    {
        get { return _selectedVNode; }
        set
        {
            if (value != _selectedVNode)
            {
                _selectedVNode = value;
                NotifyPropertyChanged("SelectedVNode");
            }
        }
    }
