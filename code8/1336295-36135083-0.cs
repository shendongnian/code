    public delegate void VisibilityChangedEventHandler(object visibilityDictionary);
    public class WPFCustomVisibilityBehavior : Behavior<DependencyObject>
    {
        #region Fields
        public static event VisibilityChangedEventHandler OnVisibilityChanged;
        private Control _control = null;
        private ContextMenu _contextMenu;
        private bool _contextMenuIsBuilt = false;
        #endregion
        #region Properties
        public bool AllowCustomVisibility
        {
            get { return (bool)GetValue(AllowCustomVisibilityProperty); }
            set { SetValue(AllowCustomVisibilityProperty, value); }
        }
        public static readonly DependencyProperty AllowCustomVisibilityProperty = DependencyProperty.Register("AllowCustomVisibility", typeof(bool), typeof(WPFCustomVisibilityBehavior), new PropertyMetadata(false));
        public string VisibilityGroupName
        {
            get { return (string)GetValue(VisibilityGroupNameProperty); }
            set { SetValue(VisibilityGroupNameProperty, value); }
        }
        public static readonly DependencyProperty VisibilityGroupNameProperty = DependencyProperty.Register("VisibilityGroupName", typeof(string), typeof(WPFCustomVisibilityBehavior), new PropertyMetadata(string.Empty));
        public Dictionary<string, bool> VisibilityDictionary
        {
            get { return (Dictionary<string, bool>)GetValue(VisibilityDictionaryProperty); }
            set { SetValue(VisibilityDictionaryProperty, value); }
        }
        public static readonly DependencyProperty VisibilityDictionaryProperty = DependencyProperty.Register("VisibilityDictionary", typeof(Dictionary<string, bool>), typeof(WPFCustomVisibilityBehavior), new PropertyMetadata(new Dictionary<string, bool>()));
        #endregion
        #region Constructor
        public WPFCustomVisibilityBehavior()
        {
            OnVisibilityChanged += VisibilityChanged;
        }
        #endregion
        #region Overrrides
        protected override void OnAttached()
        {
            base.OnAttached();
            if (this.AllowCustomVisibility == false)
            {
                return;
            }
            this._control = this.AssociatedObject as Control;
            if (!string.IsNullOrEmpty(this.VisibilityGroupName) && this._control != null)
            {
                if (this.VisibilityDictionary.ContainsKey(this.VisibilityGroupName))
                {
                    if (this.VisibilityDictionary[this.VisibilityGroupName])
                    {
                        this._control.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this._control.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    this.VisibilityDictionary.Add(this.VisibilityGroupName, this._control.Visibility == Visibility.Visible ? true : false);
                }
            }
            // Add a ContextMenu to the Control, but only if it does not already have one (TextBox brings its default ContextMenu for copy, cut and paste)
            if (this._control != null && this._control.ContextMenu == null && !(this._control is TextBox))
            {
                this._contextMenu = new ContextMenu();
                ContextMenuService.SetContextMenu(this._control, this._contextMenu);
                this._control.ContextMenuOpening += (sender, e) => { ContextMenuOpening(e); };
            }
        }
        #endregion
        #region Event handling
        private void ContextMenuOpening(ContextMenuEventArgs e)
        {
            if (this._contextMenuIsBuilt == false)
            {
                // Clear Items just to be sure there is nothing in it...
                this._contextMenu.Items.Clear();
                // Create default items first
                MenuItem showAll = new MenuItem() { Header = "Show all optional fields", IsCheckable = false, FontWeight = FontWeights.Bold };
                showAll.Click += MenuItem_ShowAll_Click;
                MenuItem hideAll = new MenuItem() { Header = "Hide all optional fields", IsCheckable = false, FontWeight = FontWeights.Bold };
                hideAll.Click += MenuItem_HideAll_Click;
                // Create field items and sort them by name
                Dictionary<string, MenuItem> menuItems = new Dictionary<string, MenuItem>();
                foreach (string k in this.VisibilityDictionary.Keys)
                {
                    MenuItem menuItem = new MenuItem() { Header = k, Name = k, IsCheckable = true, StaysOpenOnClick = true };
                    menuItem.Click += MenuItem_Click;
                    menuItems.Add(k, menuItem);
                }
                var keyList = menuItems.Keys.ToList();
                keyList.Sort();
                // Now add default items followed by field items
                this._contextMenu.Items.Add(showAll);
                this._contextMenu.Items.Add(hideAll);
                this._contextMenu.Items.Add(new Separator());
                foreach (string key in keyList)
                {
                    this._contextMenu.Items.Add(menuItems[key]);
                }
                this._contextMenuIsBuilt = true;
            }
            foreach (Object o in this._contextMenu.Items)
            {
                MenuItem mi = o as MenuItem;
                if (mi != null && mi.FontWeight != FontWeights.Bold)
                {
                    mi.IsChecked = this.VisibilityDictionary[mi.Name];
                }
            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem mi = sender as MenuItem;
            if (mi != null && this.VisibilityDictionary != null && this.VisibilityDictionary.ContainsKey(mi.Name))
            {
                this.VisibilityDictionary[mi.Name] = mi.IsChecked;
                OnVisibilityChanged(this.VisibilityDictionary);
            }
        }
        private void MenuItem_HideAll_Click(object sender, RoutedEventArgs e)
        {
            List<string> keys = this.VisibilityDictionary.Keys.ToList<string>();
            foreach (string key in keys)
            {
                this.VisibilityDictionary[key] = false;
            }
            OnVisibilityChanged(this.VisibilityDictionary);
        }
        private void MenuItem_ShowAll_Click(object sender, RoutedEventArgs e)
        {
            List<string> keys = this.VisibilityDictionary.Keys.ToList<string>();
            foreach (string key in keys)
            {
                this.VisibilityDictionary[key] = true;
            }
            OnVisibilityChanged(this.VisibilityDictionary);
        }
        private void VisibilityChanged(object visibilityDictionary)
        {
            if (this._control != null && this.VisibilityDictionary != null && this.VisibilityDictionary == visibilityDictionary && !string.IsNullOrEmpty(this.VisibilityGroupName))
            {
                if (this.VisibilityDictionary.ContainsKey(this.VisibilityGroupName))
                {
                    if (this.VisibilityDictionary[this.VisibilityGroupName])
                    {
                        this._control.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this._control.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
        #endregion
    }
}
 
