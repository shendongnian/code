    public class GlassButton : Button
    {
        static GlassButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata( typeof( GlassButton ),
                new FrameworkPropertyMetadata( typeof( GlassButton ) ) );
        }
    }
