    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
    
    namespace WpfApplication9
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<TreeViewDataModel> TreeObservableCollection { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                TreeObservableCollection = new ObservableCollection<TreeViewDataModel>();
                this.DataContext = this;
                this.Loaded += MainWindow_Loaded;
            }
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                addNewLocNode(new StringItem("A"));
                addNewLocNode(new StringItem("B"));
                addNewLocNode(new StringItem("C"));
                addNewLocNode(new StringItem("D"));
            }
            private TreeViewDataModel createNewNode(StringItem nodeName)
            {
                var newNode = new TreeViewDataModel()
                {
                    DisplayName = nodeName
                };
                newNode.Children.Add(new TreeViewDataModel() { DisplayName = nodeName });
                return newNode;
            }
    
            public void addNewLocNode(StringItem nodeName)
            {
                TreeObservableCollection.Add(createNewNode(nodeName));
            }
        }
        public class StringItem
        {
            public string Value { get; set; }
            public StringItem(string val)
            {
                Value = val;
            }
        }
        public class TreeViewDataModel : System.ComponentModel.INotifyPropertyChanged
        {
            public StringItem DisplayName { get; set; }
            private ObservableCollection<TreeViewDataModel> _children;
            public ObservableCollection<TreeViewDataModel> Children
            {
                get { return _children ?? (_children = new ObservableCollection<TreeViewDataModel>()); }
                set
                {
                    _children = value;
                    NotifyPropertyChange("Children");
                }
            }
            private void NotifyPropertyChange(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(name));
            }
            #region INotifyPropertyChanged Members
    
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
            #endregion
        }
    }
