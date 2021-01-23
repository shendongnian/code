    private void Heder_A_Update_Click(object sender, RoutedEventArgs e)
        {
            var newHederText = MyTextBox.Text;
            
            var temp = new DataTemplate();
            temp.VisualTree = new FrameworkElementFactory(typeof(TextBlock));
            temp.VisualTree.SetValue(TextBlock.TextProperty, newHederText);
            dataGrid.Columns[0].HeaderTemplate = temp;
        }
