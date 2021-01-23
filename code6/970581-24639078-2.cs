        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
        }
        void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        {
            if (MyTextBox.FocusState != FocusState.Unfocused)
            {
                if (args.VirtualKey == VirtualKey.Number0 ||
                    args.VirtualKey == VirtualKey.Number1 ||
                    args.VirtualKey == VirtualKey.Number2 ||
                    args.VirtualKey == VirtualKey.Number3 ||
                    args.VirtualKey == VirtualKey.Number4 ||
                    args.VirtualKey == VirtualKey.Number5 ||
                    args.VirtualKey == VirtualKey.Number6 ||
                    args.VirtualKey == VirtualKey.Number7 ||
                    args.VirtualKey == VirtualKey.Number8 ||
                    args.VirtualKey == VirtualKey.Number9)
                {
                    args.Handled = false;
                }
                else
                {
                    args.Handled = true;
                }
            }
        }
