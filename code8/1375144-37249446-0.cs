    private void sequenceGrid1_MouseLeave(object sender, MouseEventArgs e)
        {
            PreviewMouseLeftButtonDown += mouseClick;
        }
        private void mouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hitTestResult;
            hitTestResult = VisualTreeHelper.HitTest(sequenceGrid1, e.GetPosition(sequenceGrid1));
            if (hitTestResult == null) // Click outside the datagrid
            {
                sequenceGrid1.CommitEdit(DataGridEditingUnit.Row, true);
                try
                {
                    sequenceGrid1.Items.Refresh(); // Edit mode still open if there is invalid input
                }
                catch { }
            }
            PreviewMouseLeftButtonDown -= mouseClick;
        }
    }
