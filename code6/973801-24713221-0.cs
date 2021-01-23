    namespace CSharpWPF
    {
        public sealed class EmployeeContextMenu : INotifyPropertyChanged
        {
            private EmployeeContextMenu()
            {
                //prevent init
            }
            static EmployeeContextMenu()
            {
                Instance = new EmployeeContextMenu();
                Instance.EmployeeMenu = new ContextMenu();
            }
            public static EmployeeContextMenu Instance { get; private set; }
            private ContextMenu _menu;
            public ContextMenu EmployeeMenu
            {
                get
                {
                    return _menu;
                }
                set
                {
                    _menu = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("EmployeeMenu"));
                }
            }
            public void Set(List<String> employees)
            {
                EmployeeMenu = new ContextMenu();
                MenuItem mi;
                foreach (var item in employees)
                {
                    mi = new MenuItem();
                    mi.Header = item;
                    EmployeeMenu.Items.Add(mi);
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
