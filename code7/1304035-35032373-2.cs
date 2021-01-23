    private Row _selectedItem; 
    private void tblbRow_TextChanged(object sender, TextChangedEventArgs e)
        {           
            foreach(var item in lbKeys.Items.Cast<Row>())
            {
                if(item.IsChanged)
                {
                    _selectedItem = item;
                    item.IsChanged = false;
                }
                item.IsChanged = false; // clear all possibe text changes in future
            }
        }
  
