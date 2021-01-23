        private void TestForm_Load(object sender, EventArgs e)
        {
            // find the column with the spacer and back up its width
            int column = tableLayoutPanel.GetColumn(radioButtonSpacer);
            int width = tableLayoutPanel.GetColumnWidths()[column];
            // hide the spacer
            radioButtonSpacer.Visible = false;
            // set the column to the fixed width retrieved before
            tableLayoutPanel.ColumnStyles[column].SizeType = SizeType.Absolute;
            tableLayoutPanel.ColumnStyles[column].Width = width;
        }
