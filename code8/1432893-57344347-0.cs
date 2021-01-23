    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Panel panel1 = new Panel();
            panel1.BackColor = Color.Yellow;
            panel1.Location = new Point(400, 30);
            panel1.Size = new Size(300, 300);
            panel1.Parent = this;
            this.Controls.Add(panel1);
            label1.AutoSize = true;
            label1.ForeColor = Color.Black;
            label1.Text = "this is the text whose center I want to align";
            label1.Location = new Point(panel1.Location.X + panel1.Width / 2 - label1.Width / 2, 80);
        }
    }
