    public class SpecialAppointment: Appointment
    {
      private int _totalSalesmen = 0;
      public int TotalSalesmen 
      {get {return _totalSalesmen; }
      {set {_totalSalesmen = value; OnPropertyChanged(()=> this.TotalSalesmen);}
    }
