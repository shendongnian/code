    public sealed partial class NumberControl : UserControl
    {
        public NumberControl()
        {
            this.InitializeComponent();
            this.DataContext = this; //Remove this line 
        }
    //...
