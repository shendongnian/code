        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register(
                "Start",
                typeof(double),
                typeof(CircleSegment),
                new FrameworkPropertyMetadata(
                    0.0,
                    FrameworkPropertyMetadataOptions.AffectsRender));
        /// <summary>
        /// Start of the Segment. 0 is top (12 o'clock), 0.25 is right (3 o'clock), 0.25 is bottom (6 o'clock), 0.75 is left (9 o'clock).
        /// Painting is always Clockwise from Start to End.
        /// </summary>
        [TypeConverter(typeof(LengthConverter))]
        public double Start
        {
            get { return (double)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }
