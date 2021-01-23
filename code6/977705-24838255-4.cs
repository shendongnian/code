    // use this method to get the count of checked boxes; 
    private int GetCountOfCheckedBoxes()
    {
            List<bool?> lstOfCheckBoxesValues = new List<bool?>();
            lstOfCheckBoxesValues.Add(Cb1.IsChecked);
            lstOfCheckBoxesValues.Add(Cb2.IsChecked);
            lstOfCheckBoxesValues.Add(Cb3.IsChecked);
            // add your other CheckedBoxes similarly
            return   LstCheckBox.Where(m=> m.CurrentState == true).ToList().Count;
    }
    private void btnAddtoCompare_Click(object sender, RoutedEventArgs e)
    {
        var countCheckedBoxes = GetCountOfCheckedBoxes();
           
        if(countCheckedBoxes == 2)
        {
             // everything is fine
        }
        else
        {
             // show your error message
        }
    }
