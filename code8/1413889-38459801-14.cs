    using System.Windows;
    namespace ComboDemo
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var vm = new ViewModels.ComboDemoViewModel();
                vm.Populate();
                DataContext = vm;
            }
        }
    }
