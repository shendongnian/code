    using Caliburn.Micro;
    using MyProject.Core;
    using MyProject.Repositories;
    using MyProject.Types;
    using MyProject.ViewModels.Interfaces;
    
    namespace MyProject.ViewModels
    {
        public class LoginViewModel : Screen, ILoginViewModel
        {
            private readonly IWindowManager _windowManager;
            private readonly IUnitRepository _unitRepository;
            public bool IsLoginValid { get; set; }
            public Unit LoggedInUnit { get; set; }
    
            private string _password;
            public string UserPassword
            {
                get { return _password; }
                set
                {
                    _password = value;
                    NotifyOfPropertyChange(() => UserPassword);
                    NotifyOfPropertyChange(() => CanLogin);
                }
            }
    
            private string _name;
            public string Username
            {
                get { return _name; }
                set
                {
                    _name = value;
                    NotifyOfPropertyChange(() => Username);
                    NotifyOfPropertyChange(() => CanLogin);
                }
            }
            public LoginViewModel(IWindowManager windowManager,IUnitRepository unitRepository)
            {
                _windowManager = windowManager;
                _unitRepository = unitRepository;
                DisplayName = "MyProject - Login";
                Version = ApplicationVersionRepository.GetVersion();
            }
    
            public string Version { get; private set; }
    
            public void Login()
            {
                // Login logic
                var credentials = new UserCredentials { Username = Username, Password=UserPassword };
    
                var resp = _unitRepository.AuthenticateUnit(credentials);
                if (resp == null) return;
                if (resp.IsValid)
                {
                    IsLoginValid = true;
                    LoggedInUnit = resp.Unit;
                    TryClose();
                }
                else
                {
                    var dialog = new MessageBoxViewModel(DialogType.Warning, DialogButton.Ok, "Login Failed", "Login Error: " + resp.InvalidReason);
                    _windowManager.ShowDialog(dialog);
                }
            }
    
            public bool CanLogin
            {
                get
                {
                    return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(UserPassword);
                }
            }
        }
    }
