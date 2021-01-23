    void OnSelectionChanged(Object sender, ChangedEventArgs e){
        if(DataGridView1.CurrentCell.RowIndex == 4){
            // Show one single ComboBox in the specified Cell in the Row 4 (actually Row 3 because RowIndex is zero-based)
            if(this.Controls.Contains(ComboBox1))
                this.Controls.Remove(ComboBox1);
            
            ComboBox ComboBox1 = gcnew ComboBox();
            // Define the properties of your combobox:
            ComboBox1.Text = "Choose an Option...";
            ComboBox1.AutoSize = false; // Important, because you will change the size programmatically
            // ...
            // Get the boundaries of the desired cell
            Rectangle CellBounds = DataGridView1.GetCellDisplayRectangle(
                /*ColumnIndex*/ 1,
                /*RowIndex*/ DataGridView1.CurrentCell.RowIndex,
                /*CutOverflow*/ false);
            // By applying size and location to the combobox you make sure it is displayed on the cell
            ComboBox1.Size = CellBounds.Size;
            ComboBox1.Location = CellBounds.Location;
            
            // Add the ComboBox to your Controls in order to get it rendered when your window is shown
            this.Controls.Add(ComboBox1);
    }
