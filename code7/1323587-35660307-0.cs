    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            Label lbl = new Label();
            lbl.Location = new Point(10, 10);
            lbl.Width = 150;
            lbl.Height = 150;
            lbl.BackColor = Color.Transparent;
            lbl.Text = @"asdfasdfasdfasdf\r\nasdfasdfasdf\r\n\r\nasdfasdfasdf";
            lbl.Visible = true;
            this.Controls.Add(lbl);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(10, 10, 100, 100));
            e.Graphics.FillEllipse(Brushes.Yellow, new Rectangle(10, 10, 100, 100));
        }
    }
