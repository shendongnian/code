        public readonly static DependencyProperty MyOwnDPIDeclaredInMyUcProperty = DependencyProperty.Register(
        "MyOwnDPIDeclaredInMyUc", typeof(string), typeof(MyUserControl), new PropertyMetadata(""));
        public bool MyOwnDPIDeclaredInMyUc
        {
            get { return (string)GetValue(MyOwnDPIDeclaredInMyUcProperty); }
            set { SetValue(MyOwnDPIDeclaredInMyUcProperty, value); }
        }
