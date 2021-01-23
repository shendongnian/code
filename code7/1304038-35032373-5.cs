    private void tblbRow_GotFocus(object sender, RoutedEventArgs e)
       {
            var textBox = sender as TextBox;
            lbKeys.SelectedItem = textBox.Tag;                       
       }
   
    private void btDelTemplate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in lbKeys.Cast<Row>())
                {
                    if (item.Template.Id == (lbKeys.SelectedItem as Row).Template.Id)
                    {
                        _viewModel.RemoveTemplate(item);
                        break;
                    }
                }               
                DataContext = _viewModel;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
