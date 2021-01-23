        List<string> UsedColors = new List<string>();
        public Form1()
        {
            InitializeComponent();
            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.DefaultCellStyle.BackColor = RandColor();
        }
        private Color RandColor()
        {
            Random x = new Random();
                    int r,g,b;
            Color myRgbColor = new Color();
            while(true)
            {
                r = x.Next(0,255);
                g = x.Next(0,255);
                b = x.Next(0,255);
                if(!UsedColors.Contains( r + "," + g + "," + b ))
                {
                    UsedColors.Add( r + "," + g + "," + b );
                    break;
                }
            }
            myRgbColor = Color.FromArgb( r , g , b );
            return myRgbColor;
        }
