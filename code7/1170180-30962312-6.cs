    public class PatientsMgr :  INotifyPropertyChanged
    {
        private ObservableCollection<Patient> _ComboBoxItemsCollection;
        public ObservableCollection<Patient> ComboBoxItemsCollection
        {
            get
            {
                return _ComboBoxItemsCollection;
            }
            set
            {
                _ComboBoxItemsCollection = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ComboBoxItemsCollection"));
            }
        }
        private Patient _SelectedPatient;
        public Patient SelectedPatient
        {
            get { return _SelectedPatient; }
            set
            {
                _SelectedPatient = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedPatient"));
            }
        }
        public ICommand ChangeNameCommand { get; set; }
        public ICommand AddPatientCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        public PatientsMgr()
        {
            ComboBoxItemsCollection = new ObservableCollection<Patient>();
            ComboBoxItemsCollection.Add(new Patient() { FullName = "Patient1" });
            ComboBoxItemsCollection.Add(new Patient() { FullName = "Patient2" });
            ComboBoxItemsCollection.Add(new Patient() { FullName = "Patient3" });
            ChangeNameCommand = new RelayCommand<Patient>(ChangePatientName);
            AddPatientCommand = new RelayCommand<Patient>(AddPatient);
        }
        public void ChangePatientName(Patient patient)
        {
            patient.FullName = "changed at request";
        }
        public void AddPatient(Patient p)
        {
            ComboBoxItemsCollection.Add(new Patient() { FullName = "patient added" });
        }
    }
