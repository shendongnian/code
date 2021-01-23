    public partial class Home : ContentPage
    {
        public ObservableCollection<Appointment> appointmentList;
    
        public Home ()
        {
            InitializeComponent ();
    
            appointmentList = new ObservableCollection<Appointment>()
            {
                new Appointment { Name = "Tom Tommen", AppointmentDate = DateTime.Now }
            };
    
            appointmentsView.ItemsSource = appointmentList;
        }
    }
    
    public class Appointment
    {
        public string Name { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
