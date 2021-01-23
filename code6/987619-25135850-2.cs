    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
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
                ViewModel vm = new ViewModel();
                vm.Ok = new MyStruct { Parent = vm, IsChecked = false };
                this.DataContext = vm;
            }
        
        }
        public class ViewModel : INotifyPropertyChanged
        {
            private string txt;
            public string Txt
            {
                get { return txt; }
                set { txt = value; this.OnPropertyChanged("Txt"); }
            }
            private MyStruct ok;
            public MyStruct Ok
            {
                get { return ok; }
                set { ok = value; this.OnPropertyChanged("Ok"); }
            }
            private void OnPropertyChanged(string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public struct MyStruct
        {
            private bool _isChecked;
            public bool IsChecked
            {
                get { return _isChecked; }
                set { _isChecked = value; }
            }
            public ViewModel Parent { get; set; }
        }
    }
