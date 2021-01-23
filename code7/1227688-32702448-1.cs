    public partial class Form1 : Form
    {
        //Globals
        Form f;
        Task t;
        public Form1()
        {
            InitializeComponent();
            f = new Form();
            f.Name = "testForm";
            f.BackColor = Color.Blue;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Bounds = new System.Drawing.Rectangle(0, 0, 100, 100);
            f.TopMost = true;
            f.Opacity = 0.5;
            Application.EnableVisualStyles();
            //f.Show();
             t = Task.Run(() => Application.Run(f));
        }
        private void btn_CloseForm_Click(object sender, EventArgs e)
        {
            if (f.InvokeRequired)
            {
                this.Invoke(new CloseForm_Delegate(CloseForm));
            }
        }
        delegate void CloseForm_Delegate();
        private void CloseForm()
        {
            f.Close();
        }
        private void btn_MoveForm_Click(object sender, EventArgs e)
        {
            if (f.InvokeRequired)
            {
                //set form position here
                this.Invoke(new MoveForm_Delegate(MoveForm), new Point(0, 0));
            }
        }
        delegate void MoveForm_Delegate(Point p);
        private void MoveForm(Point p)
        {
            f.Location = p;
        }
    }
