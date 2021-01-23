    public partial class Form1 : Form
    {
        static bool switcher = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void checkBoxFont_CheckedChanged(object sender, EventArgs e)
        {
            
            switcher = !switcher;
            // Toggle between 12 Arial and 10 Times (or whatever you want).
            checkBoxFont.Font = switcher ? new Font("Times New Roman", 10F) : new Font("Arial", 12F);
        }
    }
