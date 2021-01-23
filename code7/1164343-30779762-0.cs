    public partial class ExampleWindow : Window
    {
        public ExampleWindow()
        {
            // In the constructor this should always work!
            var predValues = new List<MyComboBoxItem>();
            // Fill it with something
         
            comboPredict.ItemsSource = predValues;
            comboPredict.SelectedIndex = 0;
        }
    }
