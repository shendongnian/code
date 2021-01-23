    private void Button1_OnClick(object sender, RoutedEventArgs e) {
                try {
                    NodeBarcode_1_GetFocusNow = false; // <--- Here
                    NodeBarcode_2_GetFocusNow = true;
    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            private void Button2_OnClick(object sender, RoutedEventArgs e) {
                try {
                    NodeBarcode_1_GetFocusNow = true;
                    NodeBarcode_2_GetFocusNow = false; // <--- Here
    
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
