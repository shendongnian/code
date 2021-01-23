    #region Assembly System.Windows.dll, v2.0.50727
    using System.Windows;
    using System.Windows.Markup;
    
    namespace System.Windows.Media
    {
        // Summary:
        //     Paints an area with a solid color.
        [ContentProperty("Color", true)]
        public sealed class SolidColorBrush : Brush
        {
            // Summary:
            //     Identifies the System.Windows.Media.SolidColorBrush.Color dependency property.
            //
            // Returns:
            //     The identifier for the System.Windows.Media.SolidColorBrush.Color dependency
            //     property.
            public static readonly DependencyProperty ColorProperty;
    
            // Summary:
            //     Initializes a new instance of the System.Windows.Media.SolidColorBrush class
            //     with no color.
            public SolidColorBrush();
            //
            // Summary:
            //     Initializes a new instance of the System.Windows.Media.SolidColorBrush class
            //     with the specified System.Windows.Media.Color.
            //
            // Parameters:
            //   color:
            //     The color to apply to the brush.
            public SolidColorBrush(Color color);
    
            // Summary:
            //     Gets or sets the color of this System.Windows.Media.SolidColorBrush.
            //
            // Returns:
            //     The brush's color. The default value is System.Windows.Media.Colors.Transparent.
            public Color Color { get; set; }
        }
    }
