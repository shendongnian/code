            DataGridViewColumn LinePrice = new DataGridViewColumn();
            LinePrice.HeaderText = "Line Price";
            LinePrice.Width = 100;
            LinePrice.ReadOnly = true;
            LinePrice.CellTemplate = new DataGridViewTextBoxCell();    // Define the cell type of the new column
            CurrentLine.Columns.Add(LinePrice);
