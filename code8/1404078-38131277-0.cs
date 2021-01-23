    private void SelectCorrectComboBox(ShilListItemArgs e)
        {
            DataGrid.ScrollIntoView(e.Item);
            var rowIndex= DataGrid.SelectedIndex;
            var row = DataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            var cell = GetCell(DataGrid, row, 3) as DataGridCell;
            if (cell!=null)
            {
                cell.IsEditing = true;
                cell.IsSelected = true;
                var contentpresenter = cell.Content as ContentPresenter;
                if (contentpresenter != null)
                {
                    contentpresenter.ApplyTemplate();
                    var content = contentpresenter.ContentTemplate.FindName("CboItems",contentpresenter);
                    var comboBox = content as ComboBox;
                    if (comboBox != null)
                    {
                        comboBox.Template.LoadContent();
                        comboBox.SelectedIndex = 0;
                        comboBox.Focus();
                        Task.Run(() =>
                        {
                            Thread.Sleep(100);
                            var edit = (TextBox)comboBox.Template.FindName("PART_EditableTextBox", comboBox);
                            if (edit!=null)
                            {
                                Application.Current.Dispatcher.Invoke((Action) delegate
                                {
                                    SetTextBox(edit);
                                });
                            }
                        });
                    }
                }
            }
        }
        void SetTextBox(TextBox t)
        {
            t.Focus();
        }
