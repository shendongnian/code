	public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            Form2 form2 = new Form2(); //this must be declared in form1
        	if (form2.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                textBoxInForm1.Text = form2.InputText; //grab the input text
	        }
        }
    }
