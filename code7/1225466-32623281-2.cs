	public partial class MultipleTextBoxControl : UserControl
	{
		// this gets created by the DI framework, with identifier set automatically
		[Inject] private TextBoxData newTextBoxGroup { get; set; }
		// this get injected automatically when the class is create
		[Inject] private IDataRegistrationService DataService {get; set;}
		public MultipleTextBoxControl()
		{
			InitializeComponent();
		}
		// this gets called immediately after the constructor
		public void Initialize()
		{
			// and you do any custom initialization here, using injected components
			this.DataService.Register(newTextBoxGroup);
		}
