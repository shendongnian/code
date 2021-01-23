    public partial class VitalsView : ContentPage, INotifyPropertyChanged
    {
        VitalsViewModel MyCurrentViewModel { get; set; }
        PatientManager patientManager = new PatientManager ();
        PatientDemo globalPatient;
       
        public event PropertyChangedEventHandler PropertyChanged;
        public VitalsView (Patient patientZero)
        {
        InitializeComponent ();
        //BindingContext = new VitalsViewModel (patientZero);
          BindingContext = MyCurrentViewModel = new VitalsViewModel (patientZero);
        }
     }
