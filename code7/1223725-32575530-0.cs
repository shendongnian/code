    public static void LoadFile()
        {
            // Configure message box 
            string message = "Would you like to load a file?";
            string caption = "Startup";
            System.Windows.MessageBoxButton buttons = System.Windows.MessageBoxButton.YesNo;
            System.Windows.MessageBoxImage icon = System.Windows.MessageBoxImage.Information;
            // Show message box
            System.Windows.MessageBoxResult result = 
               System.Windows.MessageBox.Show(message, caption, buttons, icon);
            if(result == System.Windows.MessageBoxResult.Yes)
            {
                
            }
            else if(result == System.Windows.MessageBoxResult.No)
            {
            }
       }
