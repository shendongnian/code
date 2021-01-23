    public partial class MainWindow : Window
    {
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 dlg = new Window1();
            if(dlg.ShowDialog()??false)
            {
                MessageBox.Show(dlg.S);
            }
        }
    }
        // Dialog
    public partial class Window1 : Window
    {
        public string S
        {
            get
            {
                return this.txt1.Text;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
