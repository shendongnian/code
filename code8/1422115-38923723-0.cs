    public partial class AllergyBar : Panel
    {
        public AllergyBar(): base()
        {
            InitializeComponent();
        }
    
        int X = 0, Y=0;
    
        int height, width;
        public AllergyBar(List<String> lstAlerts): base()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "panel2";
            this.Size = new System.Drawing.Size(75, 23);
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            foreach (string alert in lstAlerts)
            {
                Label AllergyLabel = new Label();
                AllergyLabel.Text = alert;
                AllergyLabel.Location = new System.Drawing.Point(X, Y);
                AllergyLabel.AutoSize = true;
                AllergyLabel.BorderStyle = BorderStyle.FixedSingle;
                AllergyLabel.Dock = DockStyle.Fill;
                X += AllergyLabel.Width;
                this.Controls.Add(AllergyLabel);
            }
        }
    }
