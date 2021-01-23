    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Data;
    using System.Windows.Input;
    namespace WpfApplication1.ViewModels
    {
        public class CustomersViewModel : NotifyBase // replace NotifyBase by implementing INotifyPropertyChanged
        {
            public PagedCollectionView CustomerCollection { get; private set; }
            public int TotalPages { get { return (int)Math.Ceiling((double)CustomerCollection.ItemCount / (double)CustomerCollection.PageSize); } }
            public int PageNumber { get { return CustomerCollection.PageIndex + 1; } } 
            public ICommand MoveNextCommand { get { return GetValue(() => MoveNextCommand); } set { SetValue(() => MoveNextCommand, value); } }
            public ICommand MovePreviousCommand { get { return GetValue(() => MovePreviousCommand); } set { SetValue(() => MovePreviousCommand, value); } }
            public CustomersViewModel()
            {
                this.CustomerCollection = new PagedCollectionView(new ObservableCollection<Customer>
                {
                    new Customer(true, "Michael", "Delaney"),
                    new Customer(false, "James", "Ferguson"),
                    new Customer(false, "Andrew", "McDonnell"),
                    new Customer(true, "Sammie", "Hunnery"),
                    new Customer(true, "Olivia", "Tirolio"),
                    new Customer(false, "Fran", "Rockwell"),
                    new Customer(false, "Andrew", "Renard"),
                });
                this.CustomerCollection.PageSize = 3;
                this.MoveNextCommand = new ActionCommand(MoveNext);
                this.MovePreviousCommand = new ActionCommand(MovePrevious);
            
            }
            private void MoveNext()
            {
                this.CustomerCollection.MoveToNextPage();
                OnPropertyChanged("PageNumber");
            }
            private void MovePrevious()
            {
                this.CustomerCollection.MoveToPreviousPage();
                OnPropertyChanged("PageNumber");
            }
        }
        public class Customer : NotifyBase // replace NotifyBase by implementing INotifyPropertyChanged
        {
            public bool IsActive { get { return GetValue(() => IsActive); } set { SetValue(() => IsActive, value); } }
            public string FirstName { get { return GetValue(() => FirstName); } set { SetValue(() => FirstName, value); } }
            public string LastName { get { return GetValue(() => LastName); } set { SetValue(() => LastName, value); } }
            public Customer(bool isActive, string firstName, string lastName)
            {
                this.IsActive = isActive;
                this.FirstName = firstName;
                this.LastName = lastName;
            }
        }
        public class ActionCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;
            private Action _action;
            public ActionCommand(Action action)
            {
                _action = action;
            }
            public bool CanExecute(object parameter) { return true; }
            public void Execute(object parameter)
            {
                if (_action != null)
                    _action();
            }
        }
    }
