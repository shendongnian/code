    using System;
    using System.Windows;
    namespace WpfApplication.DataBinding
    {
            public partial class DataContextSample : Window
            {
                    public DataContextSample()
                    {
                            InitializeComponent();
                            this.DataContext = new YourViewModel();
                    }
            }
    }
