    public class CustomToggleButton : ToggleButton
    {
        [...]
        public String SelectedImageSource
        {
            get { return (String)GetValue(SelectedImageSourceProperty); }
            set { SetValue(SelectedImageSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SelectedImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedImageSourceProperty =
            DependencyProperty.Register("SelectedImageSource", typeof(String), typeof(CustomToggleButton), new PropertyMetadata(String.Empty));
        
    }
