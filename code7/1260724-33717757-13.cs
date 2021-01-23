            var col = new DataGridComboBoxColumn();
            dataGrid.Columns.Add(col);
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            col.ItemsSource = _scores;
            col.Header = "Added In Code";
            col.SelectedValueBinding = new Binding("ScoreData");
            //bring the ElementStyle from the xaml code by its key
            var elementStyle = this.FindResource("ElementStyle") as Style;
            col.ElementStyle = elementStyle;
            //bring the EditingElementStyle from the xaml code by its key
            var editingElementStyle = this.FindResource("EditingElementStyle") as Style;
            col.EditingElementStyle = editingElementStyle;
