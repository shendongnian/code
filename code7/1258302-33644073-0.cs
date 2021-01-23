    public class MyComboBox : UserControl {
      public ItemsSource ItemsSource {
        get { return this.ComboBox1.ItemsSource; }
        set { this.ComboBox1.ItemsSource = value; }
      }
    }
