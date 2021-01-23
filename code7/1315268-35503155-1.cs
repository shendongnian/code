        public Form1()
        {
            InitializeComponent();
            const int nOrders = 10;
            for (int n = 0; n < nOrders; n++)
            {
                flowLayoutPanel1.Controls.Add(new MyOrderControl());
            }
        }
