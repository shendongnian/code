    public partial class VitalsView : ContentPage, INotifyPropertyChanged
    {
        VitalsViewModel MyCurrentViewModel { get; set; }
        PatientManager patientManager = new PatientManager ();
        PatientDemo globalPatient;
       
        public event PropertyChangedEventHandler PropertyChanged;
        public VitalsView (PatientDemo patientZero)
        {
            InitializeComponent ();
            BindingContext = MyCurrentViewModel = new VitalsViewModel (patientZero);
            globalPatient = new PatientDemo (); // OTHER ERROR WHY CREATE NEW?
            globalPatient = patientZero;      // WHEN IT GETS REASSIGNED HERE???
        }
     }
