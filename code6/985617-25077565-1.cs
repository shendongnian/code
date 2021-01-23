        private void my_listpicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var listpicker = sender as ListPicker;
                if (listpicker != null)
                {
                    var selected_item = listpicker.SelectedItem as ListQuantityClass;
                    int quantity = selected_item.Quantity;
                    
                    // TODO: Save the value in quantity to a file or send it to a webservice
                }
            }
            catch (Exception ex)
            {
                string error_message = ex.Message;
            }
        }
