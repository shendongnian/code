    public class MainPageVM : ViewModelBase
        {
            private List<Model> _list = new List<Model>();
            public List<Model> list
            {
                get { return _list; }
                set { Set(ref _list, value); }
            }
    
    
    
            public MainPageVM()
            {
                for (int i = 0; i < 5; i++)
                {
                    list.Add(new Model("url" + i, "title" + i, "desc" + i));
                }
                RaisePropertyChanged(() => list);
            }
        }
