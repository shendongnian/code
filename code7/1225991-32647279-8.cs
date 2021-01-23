            ViewModel vm = new ViewModel();
            
            public MainWindow()
            {        
              InitializeComponent();
              DataContext = vm; 
            }
        // This is wrong and will result in StackOverflow exception
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
                 if (vm.HasErrors)
                {
                   TextBox b = (TextBox)sender;
                   b.Focus();
                 }
        }
            private void TextBox_PreviewLostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
            {    
                TextBox b = (TextBox)sender;
    
                if (vm.HasErrors)
                {
                    e.Handled = true;
    
                    b.Focus();
                    b.CaptureMouse();
                }
                else {
                    e.Handled = false;
                    b.ReleaseMouseCapture();
                }
            }               
    
            private void TextBox_PreviewKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
            {
                if (e.Key == System.Windows.Input.Key.Escape)
                {
                    TextBox b = (TextBox)sender;
                    b.Undo();
                }
            }
