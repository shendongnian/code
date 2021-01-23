    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                ToggleButton two = new ToggleButton();
                two.Content = "Two";
                two.Width = 100;
                two.Height = 50;
    
                /* Set up ToggleButton here*/
    
                this.Grid1.Children.Add(two);
    
                ToggleButton one = new ToggleButton();
                if (one == null) return;
                one.Content = "One";
                one.Width = 100;
                one.Height = 50;
                one.Margin = new Thickness(0, 0, 250, 0);
    
                this.Grid1.Children.Add(one);
    
                Binding binding = new Binding("IsChecked");
                binding.Source = two;
                binding.Mode = BindingMode.TwoWay;
                one.SetBinding(ToggleButton.IsCheckedProperty, binding);
                /* Add two to the UI */
            }
        }
    }
