        public static readonly DependencyProperty ComponentProperty = DependencyProperty.Register("Component",
           typeof(ComponentUserControlViewModel), typeof(ComponentUserControl), new PropertyMetadata(null));
        
        public ComponentUserControlViewModel Component
        {
            get { return (ComponentUserControlViewModel) GetValue(ComponentProperty ); }
            set { SetValue(ComponentProperty , value); }
        }
        
