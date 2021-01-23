       myComboBox.DrawMode = DrawMode.OwnerDrawVariable; 
       myComboBox.Height = 18; // Combobox itself is 18 pixels in height
       ...
    
       private void myComboBox_MeasureItem(object sender, MeasureItemEventArgs e) {
         e.ItemHeight = 17; // while item is 17 pixels high only
       }
