	class 2
	namespace Internship_Test
	{
		public partial class Form2 : Form
		{
			string[] user = new string[5];
			public Form2()
			{
				InitializeComponent();
			}
			public string b2;
            private Form1 _form1;   // you need to create a field for the form1
			public Form2(Form1 form1)
			{
				InitializeComponent();
				b2 = obj.b;
                _form1 = form1; 
			}
			public string username;
			private void button1_Click(object sender, EventArgs e)
			{
				username = textBox2.Text;
				//Form1 obj = new Form1(this);
                // instead of creating a new form, just pop it up:
                _form1?.Show();
				this.Hide();
			}
		}
	}
