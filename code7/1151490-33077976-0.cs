    [ContentProperty("Text")]
    public class TextBlockLineSplitter : FrameworkElement
    {
        public FontWeight FontWeight
        {
            get { return (FontWeight)GetValue(FontWeightProperty); }
            set { SetValue(FontWeightProperty, value); }
        }
        public static readonly DependencyProperty FontWeightProperty =
            DependencyProperty.Register("FontWeight", typeof(FontWeight), typeof(TextBlockLineSplitter), new PropertyMetadata(FontWeight.FromOpenTypeWeight(400)));
        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(double), typeof(TextBlockLineSplitter), new PropertyMetadata(10.0));
        public String FontFamily
        {
            get { return (String)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }
        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.Register("FontFamily", typeof(String), typeof(TextBlockLineSplitter), new PropertyMetadata("Arial"));
        public String Text
        {
            get { return (String)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(String), typeof(TextBlockLineSplitter), new PropertyMetadata(null));
        public double Interline
        {
            get { return (double)GetValue(InterlineProperty); }
            set { SetValue(InterlineProperty, value); }
        }
        public static readonly DependencyProperty InterlineProperty =
            DependencyProperty.Register("Interline", typeof(double), typeof(TextBlockLineSplitter), new PropertyMetadata(3.0));
        public List<String> Lines
        {
            get { return (List<String>)GetValue(LinesProperty); }
            set { SetValue(LinesProperty, value); }
        }
        public static readonly DependencyProperty LinesProperty =
            DependencyProperty.Register("Lines", typeof(List<String>), typeof(TextBlockLineSplitter), new PropertyMetadata(new List<String>()));
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            Lines.Clear();
            if (!String.IsNullOrWhiteSpace(Text))
            {
                string remainingText = Text;
                string textToDisplay = Text;
                double availableWidth = ActualWidth;
                Point drawingPoint = new Point();
                // put clip for preventing writing out the textblock
                drawingContext.PushClip(new RectangleGeometry(new Rect(new Point(0, 0), new Point(ActualWidth, ActualHeight))));
                FormattedText formattedText = null;
                // have an initial guess :
                formattedText = new FormattedText(textToDisplay,
                    Thread.CurrentThread.CurrentUICulture,
                    FlowDirection.LeftToRight,
                    new Typeface(FontFamily),
                    FontSize,
                    Brushes.Black);
                double estimatedNumberOfCharInLines = textToDisplay.Length * availableWidth / formattedText.Width;
                while (!String.IsNullOrEmpty(remainingText))
                {
                    // Add 15%
                    double currentEstimatedNumberOfCharInLines = Math.Min(remainingText.Length, estimatedNumberOfCharInLines * 1.15);
                    do
                    {
                        textToDisplay = remainingText.Substring(0, (int)(currentEstimatedNumberOfCharInLines));
                        formattedText = new FormattedText(textToDisplay,
                            Thread.CurrentThread.CurrentUICulture,
                            FlowDirection.LeftToRight,
                            new Typeface(FontFamily),
                            FontSize,
                            Brushes.Black);
                        currentEstimatedNumberOfCharInLines -= 1;
                    } while (formattedText.Width > availableWidth);
                    Lines.Add(textToDisplay);
                    System.Diagnostics.Debug.WriteLine(textToDisplay);
                    System.Diagnostics.Debug.WriteLine(remainingText.Length);
                    drawingContext.DrawText(formattedText, drawingPoint);
                    if (remainingText.Length > textToDisplay.Length)
                        remainingText = remainingText.Substring(textToDisplay.Length);
                    else
                        remainingText = String.Empty;
                    drawingPoint.Y += formattedText.Height + Interline;
                }
                foreach (var line in Lines)
                {
                    System.Diagnostics.Debug.WriteLine(line);
                }
            }
        }
    }
