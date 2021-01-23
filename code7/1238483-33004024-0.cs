    public sealed partial class Example : Page {
	
		public SampleCommand FirstCommand { get; set; } =
			new SampleCommand();
			
		public object SelectedItem { get; set; }
        public StandardProjectList() {
            this.InitializeComponent();
        }
    }
