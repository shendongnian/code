     public class QDatatables : BindableBase
        {
            public QDatatables()
            {
                List.CollectionChanged += List_CollectionChanged;
            }
    
            void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {            
                foreach (var item in e.NewItems)
                {
                    var test = item as QDatatable;
                    test.PropertyChanged += test_PropertyChanged;
                }            
            }
    
            void test_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "IsExpanded")
                {
                    var cur = sender as QDatatable;
                    if (cur.IsExpanded == true)
                    {
                        foreach (var item in List)
                        {
                            if (item.Name != cur.Name && item.IsExpanded == true)
                            {
                                item.IsExpanded = false;
                            }
                        }    
                    }
                    
                }
                
            }
    
            private ObservableCollection<QDatatable> _list;
            public ObservableCollection<QDatatable> List
            {
                get { return _list ?? (_list=new ObservableCollection<QDatatable>()); }
                set { SetProperty(ref _list, value); }
            }
    
                   
           
        }
