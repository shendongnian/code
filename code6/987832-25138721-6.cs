    // this is essentially a delegate to give the form of the method
    // EventHandler<SomeClass>  says the method will look like Method(object,SomeClass)
    public event EventHandler<ChangeButtonEventArgs > ChangeButton;
      //This is what you will call in the secondary window to fire the event.  
      //The main window will not see this code.
        protected virtual void OnChangeButton(object sender, ChangeButtonEventArgs e)
        {
            EventHandler<ChangeButtonEventArgs > handle = ChangeButton;
            if (handle != null)
            {
                handle(this, e);
            }
        }
