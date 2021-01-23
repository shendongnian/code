        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            string displayName = ((PropertyDescriptor)e.PropertyDescriptor).DisplayName as string;
            if (displayName != null) {
                e.Column.Header = displayName;
            }
        }
