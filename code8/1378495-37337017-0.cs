    public AppViewModel : Conductor<Screen>
    {
        public void AppViewModel()
        {
            ActivateItem(new FirstViewModel());
        }
    
        public void ActivateSecondViewModel()
        {
            // FirstViewModel will automatically be deactivated
            // and closed since we are using plain Conductor<T>
            ActivateItem(new SecondViewModel());
        }
    }
