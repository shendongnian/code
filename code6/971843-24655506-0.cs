    using Windows.Phone.UI.Input
    ...
    protected override void OnNavigatedTo(NavigationEventArgs e)
            {
            //This should be written here rather than the contructor
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
            
    void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
            {
            //This is where all your 'override backkey' code goes
            //You can put message dialog and/or cancel the back key using e.Handled = true;
            }
    
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
            {
            //remove the handler before you leave!
            HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
            }
