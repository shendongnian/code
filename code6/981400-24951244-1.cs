    this.popup.IsOpen = true; //opens our custom msgbox
    
                if (this.popup.IsOpen == true)
                {
                    scrollviewerCustom.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; //disables the scrollviewer
                    this.ApplicationBar.Disable(); //disables the application bar
                }
    //on click of OK button
    private void OKButton_Click(object sender, RoutedEventArgs e)
            {
                this.popup.IsOpen = false; //closes our msgbox
                scrollviewerCustom.VerticalScrollBarVisibility = ScrollBarVisibility.Visible; //enables the scrollviewer
                this.ApplicationBar.Enable(); //enables the application bar
            }
