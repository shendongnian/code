    public class TipFocusDecorator : Decorator
    {
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Open.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(TipFocusDecorator), 
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsOpenPropertyChanged));
        public string TipText
        {
            get { return (string)GetValue(TipTextProperty); }
            set { SetValue(TipTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TipText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TipTextProperty =
            DependencyProperty.Register("TipText", typeof(string), typeof(TipFocusDecorator), new UIPropertyMetadata(string.Empty));
        public bool HasBeenShown
        {
            get { return (bool)GetValue(HasBeenShownProperty); }
            set { SetValue(HasBeenShownProperty, value); }
        }
        // Using a DependencyProperty as the backing store for HasBeenShown.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HasBeenShownProperty =
            DependencyProperty.Register("HasBeenShown", typeof(bool), typeof(TipFocusDecorator), new UIPropertyMetadata(false));
        private static void IsOpenPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var decorator = sender as TipFocusDecorator;
            if ((bool)e.NewValue)
            {
                if (!decorator.HasBeenShown)
                    decorator.HasBeenShown = true;
                decorator.Open();
            }
            if (!(bool)e.NewValue)
            {
                decorator.Close();
            }
        }
        TipFocusAdorner adorner;
        protected void Open()
        {
            adorner = new TipFocusAdorner(this.Child);
            var adornerLayer = AdornerLayer.GetAdornerLayer(this.Child);
            adornerLayer.Add(adorner);
            MessageBox.Show(TipText);  // Change for your custom tip Window
            IsOpen = false;
        }
        protected void Close()
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(this.Child);
            adornerLayer.Remove(adorner);
            adorner = null;
        }
    }
