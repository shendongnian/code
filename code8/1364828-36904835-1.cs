    private void DgPatSrch_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var selectedItem = DgPatSrch.SelectedItem as DataRowView;
        if(selectedItem != null) {
            var id = selectedItem.Row["Pnum"].ToString();
            var name = selectedItem.Row["Pname"].ToString();
            var dob = selectedItem.Row["Dob"].ToString();
            TbPatIdReadOnly.Text = id;
            TbPatNameReadOnly.Text = name;
            TbDobReadOnly.Text = dob;
        }
    }
