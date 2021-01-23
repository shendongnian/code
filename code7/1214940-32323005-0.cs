    private void CallTabLv_SelectionChanged(object sender, SelectionChangedEventArgs e) 
    {
        string callDetailValue = "";
        dynamic selectedCallDetail;
        //When a row of call detail is selected, return the selected row's value only
        if (LineBtn1.IsChecked == true)
        {
            selectedCallDetail = CallTabLv1.SelectedItem;
        }
        if (LineBtn2.IsChecked == true)
        {
            selectedCallDetail = CallTabLv2.SelectedItem;
        }
        // I think the 'invalid' casting is happening with the "selectedCallDetail.Value" as when you clear a listbox it is no longer selected. 
        callDetailValue = (selectedCallDetail != null) ?  selectedCallDetail.Value : string.Empty;
        Clipboard.Clear();
        Clipboard.SetText(callDetailValue);
     }
