    public class MainWindowViewModel : BindableBase 
    {
        //property for button click command
        public DelegateCommand UpdateCommand { get; }
        //constructor to instantiate the buttons click command
        public MainWindowViewModel()
        {
            UpdateCommand = new DelegateCommand(() => {
               customer.CalculateTax();
               OnPropertyChanged( () => TaxAmount );
            }, customer.IsValid);
        }
        //this property maps tax from model to the view
        public string TaxAmount
        {
            get { return Convert.ToString(customer.Tax); }
            set { customer.Tax = Convert.ToDouble(value); }
        }
    }
