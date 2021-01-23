    public Scale()
        {
            InitializeComponent();
            IsVisibleChanged += Scale_IsVisibleChanged;
        }
    private void Scale_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
            {
                MouseRatings = _mouseRatings;
            }
        }
