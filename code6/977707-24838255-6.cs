        private void btnAddtoCompare_Click(object sender, RoutedEventArgs e)
        {
          var lst = LstCheckBox.Where(m=> m.CurrentState == true).ToList();
           
           if(lst.Count() == 2)
           {
             // everything is fine
           }
           else
           {
             // show your error message
           }
        }
    
