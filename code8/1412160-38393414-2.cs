    public static class MyCommands
    {
        public static readonly RoutedCommand SampleCommand = new RoutedCommand(
            nameof(SampleCommand), typeof(MyCommands), 
            new InputGestureCollection { new KeyGesture(Key.B, ModifierKeys.Alt) });
    }
