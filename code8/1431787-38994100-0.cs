    [assembly: ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
    
    namespace xyz.iOS.CustomControlRenderers
    {
        public class CustomSwitchRenderer : SwitchRenderer
        {
            protected override void OnElementChanged (ElementChangedEventArgs<Switch> e)
            {
                base.OnElementChanged (e);
                if (Control != null) 
                {
                    // do whatever you want to the UISwitch here!
                    Control.OnTintColor = UIColor.FromRGB (204, 153, 255);
                }
             }
        }
    }
