    public partial class MainForm : Form
    {
        public static System.Windows.Forms.Label diffTime;
        public MainForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            diffTime = new System.Windows.Forms.Label();
            diffTime.AutoSize = true;
            diffTime.Location = new System.Drawing.Point(113, 55);
            diffTime.Name = "diffTime";
            diffTime.Size = new System.Drawing.Size(35, 13);
            diffTime.TabIndex = 0;
            diffTime.Text = "label1";
            this.Controls.Add(diffTime);
        }
