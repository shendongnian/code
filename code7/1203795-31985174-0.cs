    public class MultiSelectEnvironmentContextControlViewModel : ViewModelBase
    {
        private string selectedVersion;
        private DomainFacade domainFacade;
        private IEnumerable<string> environments;
        public MultiSelectEnvironmentContextControlViewModel()
        {
            domainFacade = ((App)Application.Current).DomainFacade;
            EnvironmentVersions = domainFacade.GetEnvironmentVersions();
        }
        public IEnumerable<string> EnvironmentVersions { get; private set; }
        public string SelectedVersion
        {
            get { return selectedVersion; }
            set
            {
                selectedVersion = value;
                RaisePropertyChanged("SelectedVersion");
                Environments = domainFacade.GetEnvironments(SelectedVersion);
            }
        }
        public IEnumerable<string> Environments
        {
            get { return environments; }
            set
            {
                environments = value;
                RaisePropertyChanged("Environments");
            }
        }
    }
