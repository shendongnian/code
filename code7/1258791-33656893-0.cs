        private System.Windows.Forms.DataGridView myNewGrid;  // Declare a grid for this form
        private void Form1_Load(object sender, EventArgs e)
        {
            var myNewGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).BeginInit();
            this.SuspendLayout();
            myNewGrid.Parent = this;  // You have to set the parent manually so that the grid is displayed on the form
            myNewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            myNewGrid.Location = new System.Drawing.Point(100, 132);  // You will need to calculate this postion based on your other controls.  
            myNewGrid.Name = "myNewGrid";
            myNewGrid.Size = new System.Drawing.Size(240, 200);  // You said you need the grid to be 12x12.  You can change the size here.
            myNewGrid.TabIndex = 0;
            myNewGrid.CellClick += MyNewGrid_CellClick;  // Set up an event handler for CellClick.  You handle this in the MyNewGrid_CellClick method, below
            ((System.ComponentModel.ISupportInitialize)(myNewGrid)).EndInit();
            this.ResumeLayout(false);
            myNewGrid.Visible = true;
        }
        private void MyNewGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
