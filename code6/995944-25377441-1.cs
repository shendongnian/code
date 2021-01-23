    public class YourFormOrControllerName : Form //Or UserControl
    {
        private int yourDefaultValue = 0;
        public YourFormOrControllerName()
        {
            //whenever you haven't selected a specific control to setup (not a so good solution)
            //YourFormOrControllerName.KeyUp += HandleKeyUpSelected;
            //Whenever you Enter in the ListBox
            YourListBoxControlName.KeyUp += HandleKeyUpSelected;
        }
        
        private void HandleKeyUpSelected(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                YourListBoxControlName.SelectedIndex = yourDefaultValue;
            }
        }
    }
