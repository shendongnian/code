    public class TestPageVM : INotifyPropertyChanged
    {
    	#region  INotifyPropertyChanged interface
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	protected void OnPropertyChanged(string propertyName)
    	{
    	    var handler = PropertyChanged;
    	    if (handler != null)
    	        handler(this, new PropertyChangedEventArgs(propertyName));
    	}
    
    	#endregion
    
        private ObservableCollection<Appointment> appointmentList;
        public ObservableCollection<Appointment> AppoitmentList
         {
         	get{return appointmentList;}
         	set
         	{
         		appointmentList = value;
         		OnPropertyChanged("AppoitmentList");
         	}
         }
         //ctor
    
         public TestPageVM()
         {
         	appointmentList = new ObservableCollection<Appointment>();
         	AppoitmentList.Add(new Appointment(){
         		Employee = new Employee("Johm Doe"),
         		Place = "Houston",
         		DateTime = DateTime.Now
       		});
         }
      }
