    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows;
    namespace Test3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
            public List<Rectangle> RectItems { get { return _list; } set { } }
            List<Rectangle> _list = new List<Rectangle> { new Rectangle(5, 5, 10, 20), new Rectangle(50, 50, 200, 100) };
        }
    }
