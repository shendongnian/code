    public partial class MainWindow : Window {       
       DC_Reservation dataContext {
          get { return DataContext as DC_Reservation; }
       }
       private string message;
       public MainWindow() {
        InitializeComponent();
        DataContext = new DC_Reservation();
       }
       protected void Create_Reservation_Click(object sender, RoutedEventArgs e) {    
           dataContext.PersonReservation = new Reservation();//Create a reservation instance
           dataContext.PersonRoom = new Room(); //Create an instance of a room
           dataContext.myPerson = new Person();//Create an instance of a person
           CreateResRoom createReservationRoom = new CreateResRoom();//Create a instance of the CreateReservation WPF Form
           // I'm not sure whether the next line is required.
           createReservationRoom.DataContext = DataContext;
           createReservationRoom.Show();
       }
    }
