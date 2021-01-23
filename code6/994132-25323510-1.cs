    public class SignOutCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var vm = parameter as EditProfileViewModel;
            return vm != null;
        }
        public async void Execute(object parameter)
        {
            Task.Run(() => 
            {
                var vm = (EditProfileViewModel)parameter;
                var signOutSucceeded = SignOutUser();
                if (signOutSucceeded)
                {
                    vm.AfterSuccessfulSignOut();
                }
            }
        }
        
        ...
    }
