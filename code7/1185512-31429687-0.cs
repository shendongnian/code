    private void cbList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        cbList.SelectedIndex = -1;
    }
    private void cbList_DropDownClosed(object sender, EventArgs e)
    {
        foreach(CheckBox chk in cbList.Items){
            if(chk.IsChecked.HasValue && chk.IsChecked.Value){
                switch (chk.Content.ToString()) { 
                    case "one":
                        // Do something
                        break;
                    case "two":
                        // Do something
                        break;
                    case "three":
                        // Do something
                        break;
                }
            }
        }
    }
