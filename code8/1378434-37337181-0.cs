    class Container : UserControl
    {
        public UIElementCollection ContentPanelChildren
        {
            get { return this.ContentPanel.Children; }
        }
    
        ...
    }
