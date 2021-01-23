    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.InitializeTimer();
        }
        private void InitializeTimer()
        {
            this.timer1.Interval = 1500; //1.5 seconds
            this.timer1.Enabled = true; //Start
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int step = 5; //Move 5 pixels every 1.5 seconds
            //Limit till center-x of label reaches center of form's center-x
            if ((this.label1.Location.X + (this.label1.Width / 2)) < (this.ClientRectangle.Width / 2)) 
                //Move from left to right by incrementing x
                this.label1.Location = new Point(this.label1.Location.X + step, this.label1.Location.Y);
            else
                this.timer1.Enabled = false; //Stop
        }
    }
