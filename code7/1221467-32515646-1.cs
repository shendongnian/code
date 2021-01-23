    public partial class UserControl1 : ContentControl
    {
        public double DefaultWidth
        {
            get { return (double)GetValue(DefaultWidthProperty); }
            set { SetValue(DefaultWidthProperty, value); }
        }
        public static readonly DependencyProperty DefaultWidthProperty =
            DependencyProperty.Register("DefaultWidth", typeof(double), typeof(UserControl1), new PropertyMetadata(200.0));
        public UserControl1()
        {
            InitializeComponent();
        }
        protected override Size MeasureOverride(Size constraint)
        {
            Size baseSize = base.MeasureOverride(constraint);
            baseSize.Width = Math.Min(DefaultWidth, constraint.Width);
            return baseSize;
        }
        protected override Size ArrangeOverride(Size arrangeBounds)
        {
            Size baseBounds = base.ArrangeOverride(arrangeBounds);
            baseBounds.Width = Math.Min(DefaultWidth, arrangeBounds.Width);
            return baseBounds;
        }
    }
