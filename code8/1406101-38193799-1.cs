    private string barCode = string.Empty; //TO DO use a StringBuilder instead
    private void Window_Loaded(System.Object sender, System.Windows.RoutedEventArgs e)
    {
    	MainWindow.PreviewKeyDown += labelBarCode_PreviewKeyDown;
    }
    
    private void labelBarCode_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if ((44 == e.Key)) e.Handled = true;
    	barCode += e.Key;
    	//look for a terminator char (different barcode scanners output different 
        //control characters like tab and line feeds), a barcode char length and other criteria 
        //like human typing speed &/or a lookup to confirm the scanned input is a barcode, eg.
    	if (barCode.Length == 7) {
           var foundItem = DoLookUp(barCode);
           barCode = string.Empty;
        }
    }
