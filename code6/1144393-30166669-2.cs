    class ChildViewModel
    {
        ...
        public void HandleLogin()
        {
            ...
            _eventAggregator.Publish(new LoginEventArgs);
        }
    }
    class ParentViewModel : IHandle<LoginEventArgs>
    {
        public void Handle(LoginEventArgs args)
        {
            ..
        }
    }
