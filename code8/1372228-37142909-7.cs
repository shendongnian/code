    namespace SharedContextMenuTest.Themes
    {
        public partial class Generic
        {
            private void FooBar_ContextMenuOpening(object sender, ContextMenuEventArgs e)
            {
                (e.Source as FrameworkElement).ContextMenu.DataContext = e.Source;
            }
        }
    }
