    private List<Control> AllChildren(DependencyObject parent)
        {
            List<Control> _List = new List<Control>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _child = VisualTreeHelper.GetChild(parent, i);
                if (_child is Control)
                    _List.Add(_child as Control);
                _List.AddRange(AllChildren(_child));
            }
            return _List;
        }
