    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;    
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            MyViewModel mvm;
            public MainWindow()
            {
                InitializeComponent();
                mvm = new MyViewModel()
                {
                    ComboboxItems = new ObservableCollection<ComboItem>() 
                    { 
                        new ComboItem{ItemName="item1",ItemId=1},
                        new ComboItem{ItemName="item2",ItemId=2},
                        new ComboItem{ItemName="item3",ItemId=3}
                    },
                };
                this.DataContext = mvm;
            }
        }
        public class ObservableObject : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                var handler = this.PropertyChanged;
                if (handler != null)
                {
                    handler(this, e);
                }
            }
            protected void RaisePropertyChanged(String propertyName)
            {
                OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
            }
        }
        public class ComboItem : ObservableObject
        {
            private string _itemname;
            private int _itemid;
            public string ItemName
            {
                get
                {
                    return _itemname;
                }
                set
                {
                    _itemname = value;
                    RaisePropertyChanged("ItemName");
                }
            }
            public int ItemId
            {
                get { return _itemid; }
                set
                {
                    _itemid = value;
                    RaisePropertyChanged("ItemId");
                }
            }
        }
        public class MyViewModel : ObservableObject, IDataErrorInfo
        {
            private int _selectedid;
            private string _selectedname;
            public ObservableCollection<ComboItem> ComboboxItems
            {
                get;
                set;
            }
        
        
            public int SelectedID
            {
                get { return _selectedid; }
                set
                {
                    if (_selectedid != value)
                    {
                        _selectedid = value;
                        RaisePropertyChanged("SelectedID");
                   
                    }
                }
            }
            public string SelectedName
            {
                get { return _selectedname; }
                set
                {
                    if (_selectedname != value)
                    {
                        _selectedname = value;
                        RaisePropertyChanged("SelectedName");
                    }
                }
            }   
            public string Error
            {
                get { return this[SelectedName]; }
            }
            public string this[string columnName]
            {
                get {
                    switch (columnName)
                    {
                        case "SelectedName":
                            {
                                if (SelectedName!=null && ComboboxItems.Count(x => x.ItemName == SelectedName) == 0)
                                {
                                    //reset selected value to 0
                                    this.SelectedID = 0;
                                    return "Invalid selection";
                                }
                                break;
                            }
                    }
                    return null;
                }
            }
        }
    }
