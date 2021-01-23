    private ObservableCollection<ListItem> _items;
    public MyWindow()
    {
        InitializeComponent()
        _items = new ObservableCollection<ListItem>(
            calList.Select(
                cal => new ListItem {
                           Text = cal.Description,
                           IsChecked = cal.WhateverElse
                       }
            ));
        lstCalibration.Items = _items;
    }
