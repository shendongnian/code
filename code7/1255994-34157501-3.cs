    public class RectBlurEffect : ShaderEffect
    {
        private static PixelShader pixelShader = new PixelShader();
        private static PropertyInfo propertyInfo;
    
        public static readonly DependencyProperty InputProperty =
            ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RectBlurEffect), 0);
    
        public static readonly DependencyProperty UpLeftCornerProperty =
            DependencyProperty.Register("UpLeftCorner", typeof(Point), typeof(RectBlurEffect),
                new UIPropertyMetadata(new Point(0, 0), PixelShaderConstantCallback(0)));
    
        public static readonly DependencyProperty LowRightCornerProperty =
            DependencyProperty.Register("LowRightCorner", typeof(Point), typeof(RectBlurEffect),
                new UIPropertyMetadata(new Point(1, 1), PixelShaderConstantCallback(1)));
    
        public static readonly DependencyProperty FrameworkElementProperty =
            DependencyProperty.Register("FrameworkElement", typeof(FrameworkElement), typeof(RectBlurEffect),
            new PropertyMetadata(null, OnFrameworkElementPropertyChanged));
    
        static RectBlurEffect()
        {
            pixelShader.UriSource = Global.MakePackUri("RectBlurEffect.ps");
            propertyInfo = typeof(RectBlurEffect).GetProperty("InheritanceContext",
                BindingFlags.Instance | BindingFlags.NonPublic);
        }        
    
        public RectBlurEffect()
        {
            PixelShader = pixelShader;
            UpdateShaderValue(InputProperty);
            UpdateShaderValue(UpLeftCornerProperty);
            UpdateShaderValue(LowRightCornerProperty);
        }
    
        public Brush Input
        {
            get { return (Brush)GetValue(InputProperty); }
            set { SetValue(InputProperty, value); }
        }        
    
        public Point UpLeftCorner
        {
            get { return (Point)GetValue(UpLeftCornerProperty); }
            set { SetValue(UpLeftCornerProperty, value); }
        }        
    
        public Point LowRightCorner
        {
            get { return (Point)GetValue(LowRightCornerProperty); }
            set { SetValue(LowRightCornerProperty, value); }
        }
    
        public FrameworkElement FrameworkElement
        {
            get { return (FrameworkElement)GetValue(FrameworkElementProperty); }
            set { SetValue(FrameworkElementProperty, value); }
        }
            
        private FrameworkElement GetInheritanceContext()
        {
            return propertyInfo.GetValue(this, null) as FrameworkElement;
        }
    
        private void UpdateEffect(object sender, EventArgs args)
        {
            Rect underRectangle;
            Rect overRectangle;
            Rect intersect;
    
            FrameworkElement under = GetInheritanceContext();
            FrameworkElement over = this.FrameworkElement; 
    
            Point origin = under.PointToScreen(new Point(0, 0));
            underRectangle = new Rect(origin.X, origin.Y, under.ActualWidth, under.ActualHeight);
    
            origin = over.PointToScreen(new Point(0, 0));
            overRectangle = new Rect(origin.X, origin.Y, over.ActualWidth, over.ActualHeight);
    
            intersect = Rect.Intersect(overRectangle, underRectangle);
    
            if (intersect.IsEmpty)
            {
                UpLeftCorner = new Point(0, 0);
                LowRightCorner = new Point(0, 0);
            }
            else
            {
                origin = new Point(intersect.X, intersect.Y);
                origin = under.PointFromScreen(origin);
    
                UpLeftCorner = new Point(origin.X / under.ActualWidth,
                    origin.Y / under.ActualHeight);
                LowRightCorner = new Point(UpLeftCorner.X + (intersect.Width / under.ActualWidth),
                    UpLeftCorner.Y + (intersect.Height / under.ActualHeight));
            }
    
        }
            
        private static void OnFrameworkElementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            RectBlurEffect rectBlurEffect = (RectBlurEffect)d;
    
            FrameworkElement frameworkElement = args.OldValue as FrameworkElement;
    
            if (frameworkElement != null)
            {
                frameworkElement.LayoutUpdated -= rectBlurEffect.UpdateEffect; 
            }
    
            frameworkElement = args.NewValue as FrameworkElement;
    
            if (frameworkElement != null)
            {
                frameworkElement.LayoutUpdated += rectBlurEffect.UpdateEffect;
            }
        }
    }
