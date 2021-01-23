    private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //clicked column with formatted values
            if (e.ColumnIndex == formattedValueColumnIndex)
            {
                // Sort this column for the first time
                if (direction == SortOrder.None)
                {
                    // Remove the SortGlyph for all columns
                    foreach (DataGridViewColumn column in DataGridView.Columns)
                        column.HeaderCell.SortGlyphDirection = SortOrder.None;
                    direction = SortOrder.Ascending;
                }
                else
                    // Sort the same column again, reversing the SortOrder for it
                    direction = direction ==
                                SortOrder.Ascending
                                    ? SortOrder.Descending
                                    : SortOrder.Ascending;
                                if (direction == SortOrder.Ascending)
                    fieldValuesBindingSource.DataSource = new BindingList
                        <FieldValue>(
                        _context.FieldValues.Local.OrderBy(
                            item => GetFormattedValue(item.Value, item.TemplateFieldId).ToString())
                                .ToList());
                else
                    fieldValuesBindingSource.DataSource = new BindingList
                        <FieldValue>(
                        _context.FieldValues.Local.OrderByDescending(
                            item => GetFormattedValue(item.Value, item.TemplateFieldId).ToString())
                                .ToList());
            }
            //clicked column with ordinary (not-formatted) value
            else
                //and column with formatted value was sorted before the click
                if (direction != SortOrder.None)
                {
                    direction = SortOrder.None;
                    fieldValuesBindingSource.DataSource =
                        _context.FieldValues.Local.ToBindingList();
                }
        }
        void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //clicked column with formatted value - changing SortGlyph for it
            if (DataGridView.Columns[formattedValueColumnIndex].HeaderCell.SortGlyphDirection != direction)
                logBookFieldValueDataGridView.Columns[formattedValueColumnIndex].HeaderCell.SortGlyphDirection = direction;
        }
