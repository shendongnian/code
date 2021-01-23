    public partial class Form1 : Form
    {
        PictureBox child1 = new PictureBox();
        PictureBox child2 = new PictureBox();
        Panel panel1;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(539, 448);
            panel1 = new Panel();
            panel1.Size = new Size(this.Width - 30, this.Height - 50);
            panel1.AutoScroll = true;
            this.Controls.Add(panel1);
            child1.Size = new Size(50, 50);
            child1.BackColor = Color.Red;
            child1.Location = new Point(500, 500);          //child1 will be invisible after run due to it's position
            panel1.Controls.Add(child1);
            child2.Size = new Size(50, 50);
            child2.BackColor = Color.Green;
            child2.Location = new Point(10, 10);           //child2 will be visible after run
            panel1.Controls.Add(child2);
            Button butShowChild1 = new Button() { Location = new Point(70, 70), Text = "Bring Control Into View", AutoSize = true };
            panel1.Controls.Add(butShowChild1);
            butShowChild1.Click += butShowChild1_Click;
        }
        private void butShowChild1_Click(object sender, EventArgs e)
        {
            //Set panel1 scrollbars position to make child1 visible            
            panel1.ScrollControlIntoView(child1);
        }
    }
