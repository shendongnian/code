    class MyMenuItem : MenuItem
    {
        protected override void OnClick()
        {
            ContextMenu parentContextMenu = Parent as ContextMenu;
            parentContextMenu.Closed += ContextMenu_Closed;
            parentContextMenu.IsOpen = false;
        }
        void ContextMenu_Closed(object sender, RoutedEventArgs e)
        {
            ContextMenu parent = Parent as ContextMenu;
            parent.Closed -= ContextMenu_Closed;
            base.OnClick();
        }
    }
