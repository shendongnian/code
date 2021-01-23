        private System.Windows.Forms.DataGridView myNewGrid;  // Declare a grid for this form
        private List<BattleShipRow> battleShipGrid; // Declare this here so that you can use it later to manipulate the cell contents
        private void Form1_Load(object sender, EventArgs e)
        {
            myNewGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).BeginInit();
            this.SuspendLayout();
            myNewGrid.Parent = this;  // You have to set the parent manually so that the grid is displayed on the form
            myNewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myNewGrid.Location = new System.Drawing.Point(10, 10);  // You will need to calculate this postion based on your other controls.  
            myNewGrid.Name = "myNewGrid";
            myNewGrid.Size = new System.Drawing.Size(400, 400);  // You said you need the grid to be 12x12.  You can change the size here.
            myNewGrid.TabIndex = 0;
            myNewGrid.ColumnHeadersVisible = false; // You could turn this back on if you wanted, but this hides the headers that would say, "Cell1, Cell2...."
            myNewGrid.RowHeadersVisible = false;
            myNewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            myNewGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            myNewGrid.CellClick += MyNewGrid_CellClick;  // Set up an event handler for CellClick.  You handle this in the MyNewGrid_CellClick method, below
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).EndInit();
            this.ResumeLayout(false);
            myNewGrid.Visible = true;
            LoadGridData();
        }
        public class BattleShipRow
        {
            public string Cell1 { get; set; }
            public string Cell2 { get; set; }
            public string Cell3 { get; set; }
            public string Cell4 { get; set; }
            public string Cell5 { get; set; }
            public string Cell6 { get; set; }
            public string Cell7 { get; set; }
            public string Cell8 { get; set; }
            public string Cell9 { get; set; }
            public string Cell10 { get; set; }
            public string Cell11 { get; set; }
            public string Cell12 { get; set; }
        }
        private void LoadGridData()
        {
            battleShipGrid = new List<BattleShipRow>();
            for (var i = 0; i < 12; i++)
            {
                battleShipGrid.Add(new BattleShipRow());
            }
            myNewGrid.DataSource = battleShipGrid;
        }
        private void MyNewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
