    bool isNumLockedPressed = System.Windows.Input.Keyboard.IsKeyToggled(System.Windows.Input.Key.NumLock);
    
    int numLockStatus { get; set; }
    
    public MainWindow()
    {
                if (isNumLockedPressed == true)
                {
                    numLockStatus = 1;
                    NumLock.Foreground = System.Windows.Media.Brushes.White;
                }
    
                else
                {
                    numLockStatus = 0;
                    NumLock.Foreground = System.Windows.Media.Brushes.Red;
                }
    
    }   
    
    private void NumLockKey_Press(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.NumLock && e.IsToggled)
                {
                    numLockStatus = 1;
                    NumLock.Foreground = System.Windows.Media.Brushes.White;
                }
    
                else if (e.Key == Key.NumLock && e.IsToggled == false)
                {
                    numLockStatus = 0;
                    NumLock.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
