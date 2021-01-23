    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        void Form1_Load(object sender, EventArgs e)
        {
            FindButtons(this);
        }
        private void FindButtons(Control ctl)
        {
            foreach(Control ctrl in ctl.Controls)
            {
                if (ctrl.Name.StartsWith("btnNum") && (ctrl is Button))
                {
                    Button btn = (Button)ctrl;
                    btn.Click += btn_Click;
                }
                else if(ctrl.HasChildren)
                {
                    FindButtons(ctrl);
                }
            }
        }
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txtOutput.Text = Convert.ToString(txtOutput.Text + btn.Text);
        }
    }
