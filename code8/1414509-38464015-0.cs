      public partial class CourierDeliveringEnemyReport : Form, INotifyPropertyChanged
    {
        public static string Label1 
    	{ 
    		get
    		{
    			return Label1;
    		} 
    		set
    		{
    			Label1=value;
    			OnPropertyChanged("Label1");
    		} 
    	}
    		    
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public CourierDeliveringEnemyReport()
        {
    
            InitializeComponent();
    
            label1.Text = Label1;
    		label1.DataBindings.Add(new Binding("Text", this, "Label1"));       
        }
    }
