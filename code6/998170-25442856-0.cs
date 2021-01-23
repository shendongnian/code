        public class SomeViewModel : DependencyObject
        {
            // Dependency Property
            public static readonly DependencyProperty CurrentTimeProperty =
                 DependencyProperty.Register("CurrentTime", typeof(DateTime),
                 typeof(SomeViewModel), new FrameworkPropertyMetadata(DateTime.Now));
            // .NET Property wrapper
            public DateTime CurrentTime
            {
                get { return (DateTime)GetValue(CurrentTimeProperty); }
                set { SetValue(CurrentTimeProperty, value); }
            }
        }
