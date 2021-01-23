    public static class CommandBarExtensions
    {
        public static readonly DependencyProperty HideMoreButtonProperty =
            DependencyProperty.RegisterAttached("HideMoreButton", typeof(bool), typeof(CommandBarExtensions), 
                new PropertyMetadata(false, OnHideMoreButtonChanged));
        public static bool GetHideMoreButton(UIElement element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            return (bool)element.GetValue(HideMoreButtonProperty);
        }
        public static void SetHideMoreButton(UIElement element, bool value)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            element.SetValue(HideMoreButtonProperty, value);
        }
        private static void OnHideMoreButtonChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var commandBar = d as CommandBar;
            if (e == null || commandBar == null || e.NewValue == null) return;
            var morebutton = commandBar.FindDescendantByName("MoreButton");
            if (morebutton != null)
            {
                var value = GetHideMoreButton(commandBar);
                morebutton.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                commandBar.Loaded += CommandBarLoaded;
            }
        }
        private static void CommandBarLoaded(object o, object args)
        {
            var commandBar = o as CommandBar;
            var morebutton = commandBar?.FindDescendantByName("MoreButton");
            if (morebutton == null) return;
            var value = GetHideMoreButton(commandBar);
            morebutton.Visibility = value ?  Visibility.Collapsed : Visibility.Visible;
            commandBar.Loaded -= CommandBarLoaded;
        }
    }
