    public class Page1ViewModel : BindableBase
    {
        private readonly TextBoxModel _firstName = new TextBoxModel();
        public Page1ViewModel()
        {
            _firstName.PropertyChanged += 
                (sender, args) => SubmitCommand.RaiseCanExecuteChanged();
        }
        public TextBoxModel FirstName 
        {
            get { return _firstName; }
        }
    }
