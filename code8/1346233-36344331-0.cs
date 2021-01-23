    public partial class MyView : UserControl
    {
        public MyView()
        {
            var x = myButton; //<Button Name="myButton" /> in xaml
                              // x is null
            InitializeComponent();
            x = myButton;  //x is valid
        }
    }
  
