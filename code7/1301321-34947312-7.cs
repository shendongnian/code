    using System.Windows.Controls;
    
    namespace WpfApplication2
    {
        public partial class Page1 : Page
        {
            public Page1()
            {
                InitializeComponent();
                MainWindow w = (MainWindow) App.Current.MainWindow;
                tb.Text = w.textbox.Text;
            } 
        }
    }
