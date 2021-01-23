     // Children is the property that will be valued with the content inside the tag of the control 
    [ContentProperty("Children")]
    public class DockPanelWithOverlay : Control
    {
        static DockPanelWithOverlay()
        {
            // Associate the control with its template in themes/generic.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DockPanelWithOverlay), new FrameworkPropertyMetadata(typeof(DockPanelWithOverlay)));
        }
        public DockPanelWithOverlay()
        {
            Children = new UIElementCollection(this, this);
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // once the template is instanciated, the dockPanel and overlayCOntrol can be found from the template
            // and the children of DockPanelWithOverlay can be put in the DockPanel
            var dockPanel = this.GetTemplateChild("dockPanel") as DockPanel;
            if (dockPanel != null)
                for (int i = 0; i < Children.Count; )
                {
                    UIElement elt = Children[0];
                    Children.RemoveAt(0);
                    dockPanel.Children.Add(elt);
                }
        }	
        // Here is the property to show or not the overlay
        public Visibility OverlayVisibility
        {
            get { return (Visibility)GetValue(OverlayVisibilityProperty); }
            set { SetValue(OverlayVisibilityProperty, value); }
        }
        // Here is the overlay. Tipically it could be a Texblock, 
        // or like in our example a Grid holding a TextBlock so that we could put a semi transparent backround
        public Object Overlay
        {
            get { return (Object)GetValue(OverlayProperty); }
            set { SetValue(OverlayProperty, value); }
        }
        // Using a DependencyProperty as the backing store for OverlayProperty. 
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverlayProperty =
            DependencyProperty.Register("Overlay", typeof(Object), typeof(DockPanelWithOverlay), new PropertyMetadata(null));
        public static readonly DependencyProperty OverlayVisibilityProperty =
            DependencyProperty.Register("OverlayVisibility", typeof(Visibility), typeof(DockPanelWithOverlay), new PropertyMetadata(Visibility.Visible));
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty); }
            set { SetValue(ChildrenProperty, value); }
        }
        public static readonly DependencyProperty ChildrenProperty =
            DependencyProperty.Register("Children", typeof(UIElementCollection), typeof(DockPanelWithOverlay), new PropertyMetadata(null));
    }
	
