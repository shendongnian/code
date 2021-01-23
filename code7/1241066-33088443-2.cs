    public static class Commands
    {
        private static RoutedUICommand add;
        private static RoutedUICommand remove;
        static Commands()
        {
            searchValue = new RoutedUICommand("Add", "Add", typeof(Commands));
            showCSCode = new RoutedUICommand("Remove", "Remove", typeof(Commands));
            add.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
            remove.InputGestures.Add(new KeyGesture(Key.X));
        }
        public static RoutedUICommand Add { get { return add; } }
        public static RoutedUICommand Remove { get { return remove; } }
    }
