        public partial class Form1 : Form
    {
        public static ComboBox DropDown;
        public Form1()
        {
            InitializeComponent();
            string[] listMonth = { "01", "02", "03", "04" };
            DropDown = new ComboBox();
            DropDown.Parent = this;
            DropDown.Location = new System.Drawing.Point(50, 50);
            DropDown.Items.AddRange(listMonth);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string dropDownText = DropDown.Text;
        }
    }
