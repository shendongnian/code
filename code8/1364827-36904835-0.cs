    private void DgPatSrch_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedItem = DgPatSrch.SelectedItem as DgPat;
        if(selectedItem !=null) {
            //Assuming that is the column names represent property name
            var id = selectedItem.Pnum;
            var name = selectedItem.Pname;
            var dob = selectedItem.Dob;
            TbPatIdReadOnly.Text = id;
            TbPatNameReadOnly.Text = name;
            TbDobReadOnly.Text = dob;
        }
    }
