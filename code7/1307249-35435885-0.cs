            //Replace MainUserControl with your control name
     public static readonly DependencyProperty CanUserEditProperty =
     DependencyProperty.Register("CanUserEdit", typeof(bool),
     typeof(MainUserControl));
        public bool CanUserEdit
        {
            get { return (bool)GetValue(CanUserEditProperty); }
            set { SetValue(CanUserEditProperty, value); }
        }
