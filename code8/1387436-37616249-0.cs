    [TypeConverter(typeof(ButAppearance))]    
    public class GelButton : Button
        {
            private Appearance _ButtonAppearance = new Appearance();
    
            [Category("Appearance"), Description("Appearance.")]
            public Appearance ButtonAppearance 
            {
                get { return this._ButtonAppearance; }
                set 
                {
                    this._ButtonAppearance = value;
                    this.Invalidate();
                }
            }
        }
    
    public class Appearance
            {
                private Color _Top = Color.FromArgb(255, 44, 85, 177);
                private Color _Bottom = Color.FromArgb(255, 153, 198, 241);
                private Color _Colour3 = Color.White;
                LinearGradientMode _GradientMode = LinearGradientMode.Vertical;
    
                [Category("Appearance"), Description("The Color to use for the top portion of the gradient fill of the component.")]
                public Color Top { get { return _Top; } set { _Top = value; } }
                [Category("Appearance"), Description("The Color to use for the Bottom portion of the gradient fill of the component.")]
                public Color Bottom { get { return _Bottom; } set { _Bottom = value; } }
                [Category("Appearance"), Description("Gradient fill colour 3 of the component.")]
                public Color Colour3 { get { return _Colour3; } set { _Colour3 = value; } }
                [Category("Appearance"), Description("The gradient fill mode of the component.")]
                public LinearGradientMode GradientMode { get { return _GradientMode; } set { _GradientMode = value; } }
    
            }
    
    internal class ButAppearance : ExpandableObjectConverter
    {
    }
