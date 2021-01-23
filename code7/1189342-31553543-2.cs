    public partial class Selectie : UserControl
    {
        public Selectie()
        {
            InitializeComponent();
        }
        private void Selectie_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (((MainViewModel)this.DataContext).ImageVisibility == System.Windows.Visibility.Visible)
                ((MainViewModel)this.DataContext).ImageVisibility = System.Windows.Visibility.Collapsed;
            else
                ((MainViewModel)this.DataContext).ImageVisibility = System.Windows.Visibility.Visible;
        }
    }
