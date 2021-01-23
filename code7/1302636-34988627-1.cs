            // Edit
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
                _showCellsEditingTemplate(row);
            }
    
            // Cancel
            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
                _showCellsNormalTemplate(row);
            }
    
            // Commit
            private void Button_Click_3(object sender, RoutedEventArgs e)
            {
                DataGridRow row = (DataGridRow)DGrid.ItemContainerGenerator.ContainerFromItem(DGrid.CurrentItem);
                _showCellsNormalTemplate(row, true);
            }
    
            private void _showCellsEditingTemplate(DataGridRow row)
            {
                foreach (DataGridColumn col in DGrid.Columns)
                {
                    DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                    while (parent.GetType().Name != "DataGridCell")
                        parent = VisualTreeHelper.GetParent(parent);
    
                    DataGridCell cell = ((DataGridCell)parent);
                    DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                    if(c.CellEditingTemplate !=null)
                        cell.Content = ((DataGridTemplateColumn)col).CellEditingTemplate.LoadContent();
                }
            }
    
            private void _showCellsNormalTemplate(DataGridRow row, bool canCommit = false)
            {
                foreach (DataGridColumn col in DGrid.Columns)
                {
                    DependencyObject parent = VisualTreeHelper.GetParent(col.GetCellContent(row));
                    while (parent.GetType().Name != "DataGridCell")
                        parent = VisualTreeHelper.GetParent(parent);
    
                    DataGridCell cell = ((DataGridCell)parent);
                    DataGridTemplateColumn c = (DataGridTemplateColumn)col;
                    if (col.DisplayIndex != 0)
                    {
                        if (canCommit == true)
                            ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateSource();
                        else
                            ((TextBox)cell.Content).GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                    }
                    cell.Content = c.CellTemplate.LoadContent();                
                }
            }     
 
    public class ViewModel
        {
            ObservableCollection<Student> _students = new ObservableCollection<Student>();
            public ObservableCollection<Student> Students
            { get { return _students; } set { _students = value; } }
    
            public ViewModel()
            {
                Students.Add(new Student() { Name = "Prashant", Address = "123, N2 B, Barkheda" });
                Students.Add(new Student() { Name = "Amit", Address = "123, N2 B, Piplani" });
                Students.Add(new Student() { Name = "Gopi", Address = "Subhash Nagar" });
                Students.Add(new Student() { Name = "S. Sachin", Address = "HabibGanj" });
            }
        }
    
        public class Student
        {
            public string Name { get; set; }
            public string Address { get; set; }
        }
