    // opens the popup
    // you can bind set TooltipPopup.IsOpen in any event you want (e.g. MouseEnter, Click, etc.
    private void ShowTooltip(object sender, MouseEventArgs e){
        TooltipPopup.IsOpen = true;
    }
    // doing something, when the Button in popup got clicked:
    private void UpdateTime(object sender, RoutedEventArgs e){
        TestClickTarget.Text = DateTime.Now.ToString("T");
    }
