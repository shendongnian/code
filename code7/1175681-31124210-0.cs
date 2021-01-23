    public YourClass Bind
        {
            get { return (YourClass)GetValue(BindProperty); }
            set { SetValue(BindProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Bind.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BindProperty =
            DependencyProperty.Register("Bind", typeof(YourClass), typeof(UserControl1), new PropertyMetadata(BindModified));
        private static void BindModified(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((UserControl1)d).AttachEventHandler();
        }
        private void AttachEventHandler()
        {
            //Modify what you want here
        }
