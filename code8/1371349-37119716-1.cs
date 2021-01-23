        public UserControl()
        {
            InitializeComponent();
        }
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            bool x = Keyboard.IsKeyDown(Key.System);
            if (Keyboard.IsKeyDown(Key.System) && Keyboard.IsKeyDown(Key.B))// Alt+B
            {
                txt2.Focusable = true;
                txt2.Focus();
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += KeyDownEvent;
            txt1.Focusable = true;
            txt1.Focus();
        }
    }
