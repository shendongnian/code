    public class BindingHelper : DependencyObject
    {
        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(object), typeof(MainWindow));
        public object Result
        {
            get { return GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }
    }
