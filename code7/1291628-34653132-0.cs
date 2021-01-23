    private void OnCellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        if (e.ColumnIndex == this.percentageDataGridViewTextBoxColumn.Index
            && e.DesiredType == typeof(double)
            && ContainsPercentSign(e.Value.ToString()))
            {   // parsing a percentage to a double
                var formatProvider = this.dataGridView1.Rows[e.RowIndex]
                                         .Cells[e.ColumnIndex]
                                         .InheritedStyle
                                         .FormatProvider;
                try
                {
                    e.Value = ParsePercentageToDouble(e.Value.ToString(), formatProvider);
                    e.ParsingApplied = true;
                }
                catch (FormatException)
                {
                    e.ParsingApplied = false;
                }
            }
            else
            {   // parsing any other column, let the system parse it
                e.ParsingApplied = false;
            }			
        }
    }
