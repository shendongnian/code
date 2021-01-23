    public LoginBasic()
            {
                InitializeComponent();
                //FocusManager.SetFocusedElement(this, UserNameTextBox);
                //Keyboard.Focus(UserNameTextBox);
    
                this.IsVisibleChanged += LoginControl_IsVisibleChanged; 
    
    
            }
    
    
        
    void LoginControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                Dispatcher.BeginInvoke(
                DispatcherPriority.ContextIdle,
                new Action(() => UserNameTextBox.Focus()));
            }
        } 
 
