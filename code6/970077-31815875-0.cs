    public sealed partial class Bar : UserControl
    {
        public Bar()
        {
            // This will become the error specified (does not contain definition)
            this.InitializeComponent(); 
        }
        ...
    }
