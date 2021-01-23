    public class StrokeAdorner : Adorner
    {
        private TextBlock _textBlock;
    
        private Brush _stroke;
        private ushort _strokeThickness;
    
        public Brush Stroke
        {
            get
            {
                return _stroke;
            }
    
            set
            {
                _stroke = value;
                _textBlock.InvalidateVisual();
                InvalidateVisual();
            }
        }
    
        public ushort StrokeThickness
        {
            get
            {
                return _strokeThickness;
            }
    
            set
            {
                _strokeThickness = value;
                _textBlock.InvalidateVisual();
                InvalidateVisual();
            }
        }
    
        public StrokeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            _textBlock = adornedElement as TextBlock;
            ensureTextBlock();
        }
    
        private void ensureTextBlock()
        {
            if (_textBlock == null) throw new Exception("This adorner works on TextBlocks only");
        }
    
        protected override void OnRender(DrawingContext drawingContext)
        {
            ensureTextBlock();
            base.OnRender(drawingContext);
            FormattedText formattedText = new FormattedText(
                _textBlock.Text,
                CultureInfo.CurrentUICulture,
                _textBlock.FlowDirection,
                new Typeface(_textBlock.FontFamily, _textBlock.FontStyle, _textBlock.FontWeight, _textBlock.FontStretch),
                _textBlock.FontSize,
                _textBlock.Foreground // This brush does not matter since we use the geometry of the text. 
                );
    
            // Build the geometry object that represents the text.
            var _textGeometry = formattedText.BuildGeometry(new Point(0, 0));
            drawingContext.DrawGeometry(Brushes.Transparent, new Pen(Stroke, StrokeThickness), _textGeometry);
        }
    }
    
        public class StrokeTextBlock:TextBlock
        {
            private StrokeAdorner _adorner;
            private bool _adorned=false;
    
            public StrokeTextBlock()
            {
                _adorner = new StrokeAdorner(this);
                this.LayoutUpdated += StrokeTextBlock_LayoutUpdated;
            }
    
            private void StrokeTextBlock_LayoutUpdated(object sender, EventArgs e)
            {
                if (_adorned) return;
                var adornerLayer = AdornerLayer.GetAdornerLayer(this);
                adornerLayer.Add(_adorner);
                _adorned = true;
            }
    
            private static void strokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var stb = (StrokeTextBlock)d;
                stb._adorner.Stroke = e.NewValue as Brush;
            }
    
            private static void strokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var stb = (StrokeTextBlock)d;
                stb._adorner.StrokeThickness = DependencyProperty.UnsetValue.Equals(e.NewValue)?(ushort)0:(ushort)e.NewValue;
            }
    
            /// <summary>
            /// Specifies the brush to use for the stroke and optional hightlight of the formatted text.
            /// </summary>
            public Brush Stroke
            {
                get
                {
                    return (Brush)GetValue(StrokeProperty);
                }
    
                set
                {
                    SetValue(StrokeProperty, value);
                }
            }
    
            /// <summary>
            /// Identifies the Stroke dependency property.
            /// </summary>
            public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
                "Stroke",
                typeof(Brush),
                typeof(StrokeTextBlock),
                new FrameworkPropertyMetadata(
                     new SolidColorBrush(Colors.Teal),
                     FrameworkPropertyMetadataOptions.AffectsRender,
                     new PropertyChangedCallback(strokeChanged),
                     null
                     )
                );
    
            /// <summary>
            ///     The stroke thickness of the font.
            /// </summary>
            public ushort StrokeThickness
            {
                get
                {
                    return (ushort)GetValue(StrokeThicknessProperty);
                }
    
                set
                {
                    SetValue(StrokeThicknessProperty, value);
                }
            }
    
            /// <summary>
            /// Identifies the StrokeThickness dependency property.
            /// </summary>
            public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
                "StrokeThickness",
                typeof(ushort),
                typeof(StrokeTextBlock),
                new FrameworkPropertyMetadata(
                     (ushort)0,
                     FrameworkPropertyMetadataOptions.AffectsRender,
                     new PropertyChangedCallback(strokeThicknessChanged),
                     null
                     )
                );
        }
