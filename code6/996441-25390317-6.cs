    public class LauncherViewModel : ViewModelBase
    {
        private ESTContext _ESTContext;
        private string _templatename;
        private string _modelname;
        private string serialNumber;
        private string _outputname;
        private string modelName;
        private ObservableCollection<Model> models;
        private Model selectedModel;
        private string soNumber;
        public LauncherViewModel()
        {
            // dangerous ;)
            _ESTContext = new ESTContext();
            Models = new ObservableCollection<Model>(_ESTContext.Models);
        }
        public ObservableCollection<Model> Models
        {
            get { return models; }
            set
            {
                if (Equals(value, models)) return;
                models = value;
                RaisePropertyChanged();
            }
        }
        public string ModelName
        {
            get { return modelName; }
            set
            {
                if (value == modelName) return;
                modelName = value;
                RaisePropertyChanged();
            }
        }
        public string TemplateName { get { return _templatename;  }}
        public string SerialNumber // Note you spelled this wrong in your xaml. SONumber
        {
            get { return serialNumber; }
            set
            {
                if (value == serialNumber) return;
                serialNumber = value;
                RaisePropertyChanged();
            }
        }
        
        public string SONumber
        {
            get { return soNumber; }
            set
            {
                if (value == soNumber) return;
                soNumber = value;
                RaisePropertyChanged();
            }
        }
        public string OutputName { get { return _outputname; } }
        public Model SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (Equals(value, selectedModel)) return;
                selectedModel = value;
                RaisePropertyChanged();
            }
        }
    }
