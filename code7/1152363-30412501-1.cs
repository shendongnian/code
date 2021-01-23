	public partial class KnuthMorrisPrattView : UserControl
	{
		public KnuthMorrisPrattView()
		{
			InitializeComponent();
			this.TextBox.TextChanged += OnTextChanged;
		}
		
		...
		
		public void OnTextChanged(object sender, TextChangedEventArgs e) 
		{
			// Get the text from the event and set your Text Property 
			string text = ...; 
			SetText(this, text);
		}
	}
