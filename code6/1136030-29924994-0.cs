    public partial class MonthViewPage : ContentPage
    {
    
        public WeekViewDatesViewModel VM { get; set; } 
        
        public MonthViewPage ()
        {
            DataContext = VM = new  WeekViewDatesViewModel();
            InitializeComponent();
        }
    
    
        void OnButtonClicked(object sender , EventArgs args){
     
            VM.MiddleWeekViewDate = new DateTime (2014, 2, 2);
        }
    }
