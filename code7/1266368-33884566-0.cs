    public partial class Form1 : Form
    {
        SimonFunctions sf = new SimonFunctions(this); //Added
        public Form1()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            sf.Colorplaff(); //call Colorplaff from Form1;
        }
    }
    class SimonFunctions 
    {
        public static List<int> ColorNums = new List<int>();
        Form1 mainForm; //added
        public SimonFunctions (Form1 form) //Constructor added
        {
            mainForm = form;
        }
        public void ColorPlay(int x) //remove static and Form1 argument
        {
            mainForm.ButtonNum = x; //use mainForm
            if (x == 1)
                mainForm.GreenButton.BackColor = Color.Lime;
            else if (x == 2)
                mainForm.RedButton.BackColor = Color.Red;
            else if (x == 3)
                mainForm.YellowButton.BackColor = Color.Yellow;
            else if (x == 4)
                mainForm.BlueButton.BackColor = Color.Blue;
            mainForm.timer1.Start();
        }
        public void Colorplaff()
        {
            ColorPlay(1);
        }
    }
