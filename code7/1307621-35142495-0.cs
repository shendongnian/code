    private void button_Click_1(object sender, RoutedEventArgs e)
    {
        Window2 win2 = new Window2();
        win2.Wnd1Reference = this;
        this.Visibility = Visibility.Collapsed;
        win2.ShowDialog();
    }
    public partial class Window2 : Window
    {
        public Window1 Wnd1Reference {get; set;}
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Wnd1Reference.getCode = textBox.Text;
            this.Close();
            Wnd1Reference.Visibility = Visibility.Visible;
        }
    }
