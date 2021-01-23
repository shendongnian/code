        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10000; i++)
            {
                this.ultraDataSource1.Rows.Add(new object[] { i });
            }
            this.ultraGrid1.Paint += UltraGrid1_Paint;
        }
        private void UltraGrid1_Paint(object sender, PaintEventArgs e)
        {
            this.ultraGrid1.Paint -= UltraGrid1_Paint;
            Debug.WriteLine("PAINT");
        }
        private void ultraGrid1_InitializeRow(object sender, Infragistics.Win.UltraWinGrid.InitializeRowEventArgs e)
        {            
            Debug.WriteLine(e.Row.Index, "InitializeRow");
        }
