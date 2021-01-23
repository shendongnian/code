    using System;
    using Prism.Commands;
    using Prism.Events;
    using Prism.Mvvm;
    namespace MainModule.ViewModels
    {
        public abstract class ViewAViewModelBase : BindableBase
        {
            private readonly IEventAggregator _eventAggregator;
            private string _firstName;
            private string _lastName;
            private DateTime? _lastUpdated;
    
            public string FirstName
            {
                get { return _firstName; }
                set { SetProperty(ref _firstName, value); }
            }
            public string LastName
            {
                get { return _lastName; }
                set { SetProperty(ref _lastName, value); }
            }
            public DateTime? LastUpdated
            {
                get { return _lastUpdated; }
                set { SetProperty(ref _lastUpdated, value); }
            }
            public DelegateCommand UpdateCommand { get; private set; }
            public ViewAViewModelBase(IEventAggregator eventAggregator)
            {
                _eventAggregator = eventAggregator;
                UpdateCommand =
                new DelegateCommand(UpdateMethod, CanUpdateMethod)
                .ObservesProperty(() => FirstName)
                .ObservesProperty(() => LastName);
            }
            protected bool CanUpdateMethod()
            {
                return !String.IsNullOrEmpty(_lastName) && !String.IsNullOrEmpty(_firstName);
            }
            protected virtual  void UpdateMethod()
            {
                LastUpdated = DateTime.Now;
                _eventAggregator.GetEvent<Events.UpdatedAggEvent>().Publish($"User {FirstName}");
            }
        }
    }
