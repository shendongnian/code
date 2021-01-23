    public static readonly DependencyProperty SelectedIndexProperty = DependencyProperty.Register(
        "SelectedIndex",
        typeof(int),
        typeof(WhateverYourClassNameIs));
    public int SelectedIndex
    {
        get { return (int)GetValue(SelectedIndexProperty); }
        set { SetValue(SelectedIndexProperty, value); }
    }
