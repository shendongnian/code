        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            IRaiseStartCellEditEvent context = DataContext as IRaiseStartCellEditEvent;
            if (context != null)
            {
                context.StartCellEdit += (o, args) =>
                {
                    //Get the cell from first row
                    var cell = DataGrid.GetCell(0, 2);
                    //Focus on the cell for editing
                    cell.Focus();
                    //Start editing the cell
                    DataGrid.BeginEdit();
                    //Get the editing textbox
                    var tbEditor = Extensions.GetVisualChild<TextBox>(cell);
                    //Force the keyboard focus
                    if (tbEditor != null)
                    {
                        Keyboard.Focus(tbEditor);
                        tbEditor.SelectAll();
                    }
                };
            }
            }
