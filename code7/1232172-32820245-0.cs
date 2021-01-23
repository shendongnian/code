    [RunInstaller(true)]
    public class CustomInstaller : System.Configuration.Install.Installer
    {
        public CustomInstaller()
        {
            _installProcess = new ServiceProcessInstaller { Account = ServiceAccount.NetworkService };
            _installService = new CustomServiceInstaller(typeof(ServiceImplementation));
            //  Remove built-in EventLogInstaller:
            _installService.Installers.Clear();
            Installers.Add(_installProcess);
            Installers.Add(_installService);
        }
        public override void Install(IDictionary stateSaver)
        {
            //install
            base.Install(stateSaver);
        }
        protected override void OnCommitted(IDictionary savedState)
        {
            var delyed = bool.Parse(GetContextParameter(@"Delayed"));
            if (!delyed)
            {
                new ServiceController(GetContextParameter(ServiceNameKey)).Start();
            }
        }
        private string GetContextParameter(string parameterKey)
        {
            var parameterValue = Context.Parameters[parameterKey];
            if (string.IsNullOrWhiteSpace(parameterValue))
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, MissingRequiredParameterErrorMessage, parameterKey));
            return parameterValue;
        }
    }
