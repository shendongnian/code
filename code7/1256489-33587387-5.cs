    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace Q1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                List<System.Object> myList = new List<object>();
                myList.Add(1);
                myList.Add("Alpha");
                myList.Add(2);
                myList.Add("Beta");
                myList.Add(3);
                myList.Add("Gamma");
                myListBox.DataContext = myList;
            }
        }
    
    }
