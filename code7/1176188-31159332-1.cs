    public class CustomTabControl : TabControl
    {
        private static readonly DependencyPropertyKey ReadOnlyPropPropertyKey
                                = DependencyProperty.RegisterReadOnly("ReadOnlyProp", typeof(double), typeof(CustomTabControl),
                                    new FrameworkPropertyMetadata((double)0,
                                        FrameworkPropertyMetadataOptions.None));
    
        public static readonly DependencyProperty TabPanelActualHeightProperty = ReadOnlyPropPropertyKey.DependencyProperty;
    
        public double TabPanelActualHeight
        {
            get { return (double)GetValue(TabPanelActualHeightProperty); }
            protected set { SetValue(ReadOnlyPropPropertyKey, value); }
        }
    
        private TabPanel _tabPanel = null;
    
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            _tabPanel = this.GetChildOfType<TabPanel>();
    
            if (_tabPanel != null)
            {
                TabPanelActualHeight = _tabPanel.ActualHeight;
                _tabPanel.SizeChanged += TabPanelOnSizeChanged;
            }
    
        }
    
        private void TabPanelOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            TabPanelActualHeight = _tabPanel.ActualHeight;
        }
    }
