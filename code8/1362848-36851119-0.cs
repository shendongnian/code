	public partial class GeneralInputForm<T> : Form
	{
		public string result = "";
		Func<T, Boolean> check = (input, isOk) => true; // Default check
		Func<String, T> cast = null; // Default cast
		
		public GeneralInputForm(string label, T defaultValue, Func<String, T> cast, Func<T, Boolean> check)
		{
			InitializeComponent();
			label1.Text = label;
			textBox1.Text = defaultValue != null = defaultValue : "";
			if(check != null)
				this.check = check;
			this.cast = cast;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			T casted = cast(textBox1.Text);
			if(casted != null && check(casted)){
				result = textBox1.Text;
				Close();
			}
		}
	}
