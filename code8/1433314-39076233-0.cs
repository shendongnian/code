    //This function will get all the children Control of one Controls' Container
    public List<Control> AllChildren(DependencyObject parent)
    {
        var _List = new List<Control>();
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var _Child = VisualTreeHelper.GetChild(parent, i);
            if (_Child is Control)
                _List.Add(_Child as Control);
            _List.AddRange(AllChildren(_Child));
        }
        return _List;
    }
    
    private MapControl GetMapControl()
    {
        var controls = AllChildren(myContentPresenter);//"myContentPresenter" is your ContentPresenter's name.
        var mapControl = (MapControl)controls[0];
        return mapControl;
    }
