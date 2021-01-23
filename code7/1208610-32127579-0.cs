        public static class CustomCommands
        {
            public static readonly RoutedUICommand SettingsCommand = new RoutedUICommand
                (
                        "SettingsCommand",
                        "SettingsCommand",
                        typeof(CustomCommands),
                        new InputGestureCollection()
                                {
                                }
                );
        }
