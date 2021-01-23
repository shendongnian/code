        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.IsReadOnly)
            {
                e.Column.CellStyle = (Style)Resources["CellReadOnlyStyle"];
            }
            else if (other states)
            {
                e.Column.CellStyle = (Style)Resources["CellOtherStyle"];
            }
            else
            {
                e.Column.CellStyle = (Style)Resources["CellDefaultStyle"];
            }
        }
