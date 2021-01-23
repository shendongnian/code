    public class EditCommands
    {
        public static RoutedUICommand Header1 { get; private set; }
        static EditCommands()
        {
            var gestures = new InputGestureCollection();
            gestures.Add(new KeyGesture(Key.D1, ModifierKeys.Control, "Ctrl+1"));
            Header1 = new RoutedUICommand("Header 1", "Header1", typeof(EditCommands), gestures);
        }
    }
	
