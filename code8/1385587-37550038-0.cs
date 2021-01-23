    ...
            bool mouseOverMe;
    
            public MainWindow()
            {
                InitializeComponent();
                mouseOverMe = false;
            }
    
            private void Window_MouseEnter(object sender, MouseEventArgs e)
            {
                mouseOverMe = true;
            }
    
            private void Window_MouseLeave(object sender, MouseEventArgs e)
            {
                mouseOverMe = false;
            }
    
            void doSomething()
            {
                if (Mouse.LeftButton == MouseButtonState.Pressed)
                    if (mouseOverMe)
                        MessageBox.Show("Im a mouse down in the window");
            }
    ...
