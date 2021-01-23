    public bool IsReadOnly
    {
        get { return (bool)GetValue(IsReadOnlyProperty); }
        set { SetValue(IsReadOnlyProperty, value); }
    }
    public static readonly DependencyProperty IsReadOnlyProperty =
        DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(MyUserControl), new PropertyMetadata(false, (d, e) =>
        {
            var userControl = (MyUserControl)s;
            var value = (bool)e.NewValue;
            userControl.textBlock.Visible = value ? Visibility.Visible : Visibility.Hidden;
            userControl.textBox.Visible = !value ? Visibility.Visible : Visibility.Hidden;
        }));
