    public DragDropWindow()
    {
        Style itemContainerStyle = new Style(typeof(ListBoxItem));
        itemContainerStyle.Setters.Add(new Setter(ListBoxItem.AllowDropProperty, true));
        itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseLeftButtonDownEvent, new MouseButtonEventHandler(s_PreviewMouseLeftButtonDown)));
        itemContainerStyle.Setters.Add(new EventSetter(ListBoxItem.PreviewMouseMoveEvent, new MouseButtonEventHandler(s_PreviewMouseMoveEvent)));
        listbox1.ItemContainerStyle = itemContainerStyle;
    }
