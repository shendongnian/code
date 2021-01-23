    namespace StackExchange
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var lbv = new ListBoxItemSV()
                {
                    Height = 40,
                    Width= 520,
                    Background = Brushes.Blue
                };
                ListBoxControl.Items.Add(lbv);
            }
    
            public class ListBoxItemSV : ListBoxItem
            {
                ScrollViewer sv = new ScrollViewer()
                {
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Visible,
                    VerticalScrollBarVisibility = ScrollBarVisibility.Hidden
                };
                Label lbl = new Label()
                {
                    Content = "A really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really long name."
                };
    
                public ListBoxItemSV()
                {
                    sv.Content = lbl;
                    this.Content = sv;
                }
            }
        }
    }
