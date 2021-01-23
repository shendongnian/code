    using System.Windows;
    namespace WpfMagic
    {
        public partial class AnotherWindow : Window
        {
            public MyViewModel Model { get; set; }
            public AnotherWindow(MyViewModel model)
            {
                InitializeComponent();
                Model = model;
                this.DataContext = this;
            }
        }
    }
