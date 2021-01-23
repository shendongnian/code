            var dummy = new ColumnHeader();
            // dummy gets the last DisplayIndex
            listView1.Columns.Add(dummy);
            // dummy gets the remaining space instead
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            listView1.Columns.Remove(dummy);
