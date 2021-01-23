    public partial class CustomDatePicker : UserControl
    {
        public CustomDatePicker()
        {
            InitializeComponent();
    
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "dd/MM/yyyy";
        }
    }
