    public class ContextMenuItem : MenuItem
    {
        public ContextMenuItem()
            :base()
        {
        }
        //Replace by Header
        //
        //public string DisplayText { get; set; }
        //Can this be replaced by build in CommandParameter
        //
        private Dictionary<string, object> _parameters = new Dictionary<string, object>();
        
        private Func<ContextMenuItem, List<ContextMenuItem>> _getMenuItems = null; 
        
        //Already available
        //public DelegateCommand Command { get; set; }
        //What does this function do?
        public Func<ContextMenuItem, List<ContextMenuItem>> GetMenuItems
        {
            get
            {
                return _getMenuItems;
            }
            set
            {
                _getMenuItems = value;
            }
        }
        public Dictionary<string, object> Parameters
        {
            get
            {
                return _parameters;
            }
        }
        //Can be replaced by base Items
        //
        //private List<ContextMenuItem> _menuItems = new List<ContextMenuItem>();
        //public List<ContextMenuItem> ChildMenuItems
        //{
        //    get
        //    {
        //        return _menuItems;
        //    }
        //}
        private bool _isChecked = false;
        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
        // -- Command or implementer could provide a handler for all commands - might be simpler for now
        // -- I think there could be a better way to route commands but I'll thin on it.
