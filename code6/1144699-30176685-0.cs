    public class MainForm()
    {
    
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            ColorPicker ColorDialog = new ColorPicker();
            ColorDialog.ShowDialog(); // This will block until the child is closed as a true dialog normally does.
            this.Background = ColorDialog.ChosenColor;
        }
    }
    
    public class ColorPicker()
    {
        public SolidColorBrush ChosenColor{get;private set;}
    
    // Write the code for your color picker then store the value in ChosenColor.
    }
