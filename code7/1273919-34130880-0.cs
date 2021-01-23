     DataGridView table = new DataGridView();
            
            table.ColumnCount = 3;
            table.Rows.Add(3);
            table.ColumnHeadersVisible = false;
            table.RowHeadersVisible = false;
            table.ScrollBars = ScrollBars.None;
            for (int i = 0; i < 3; ++i)
                table.Columns[i].Width = 40;
            int width = 40 * 3;
            int height = 22 * 3;
            table.Width = width;
            table.Height = height;
            this.Controls.Add(table);
            table.AllowUserToAddRows = false;
