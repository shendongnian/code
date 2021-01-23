    public class SampleVm
    {
        public MenuItemVm[] MenuItems { get; set; }
    }
    public class MenuItemVm
    {
        public object Header { get; set; }
        public ICommand Command { get; set; }
    }
