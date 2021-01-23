        using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
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
    
    namespace ChkList_Learning
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
    
        class ViewModel:INotifyPropertyChanged  
        {
            public ObservableCollection<IssueType> IssueTypes { get; set; }
    
            public bool IsVisible
            {
                get { return IssueTypes.Any(x=>x.IsChecked); }
            }
    
            public ViewModel()
            {
                IssueTypes = new ObservableCollection<IssueType>();
                IssueTypes.CollectionChanged += IssueTypes_CollectionChanged;
                for (int i = 0; i < 10; i++)
                {
                    IssueTypes.Add(new IssueType() { IssueName = "IssueName"+i });
                }
            }
    
            private void IssueTypes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                if (e.OldItems != null)
                {
                    foreach (IssueType item in e.OldItems)
                        item.PropertyChanged -= new
                                               PropertyChangedEventHandler(item_PropertyChanged);
                }
    
                if (e.NewItems != null)
                {
                    foreach (INotifyPropertyChanged item in e.NewItems)
                    {
                        if (item != null)
                        {
                            item.PropertyChanged +=
                            new PropertyChangedEventHandler(item_PropertyChanged);
                        }
                    }
                        
                }
            }
    
            private void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "IsChecked")
                {
                    OnPropertyChanged("IsVisible");
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        class IssueType:INotifyPropertyChanged
        {
            private string issueName;
    
            public string IssueName
            {
                get { return issueName; }
    
                set
                {
                    issueName = value;
                    OnPropertyChanged();
                }
            }
            private bool isChecked;
    
            public bool IsChecked
            {
                get { return isChecked; }
    
                set
                {
                    isChecked = value;
                    OnPropertyChanged();
                }
            }
            
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }   
       
    }
