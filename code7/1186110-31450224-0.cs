    /// <summary>
    /// Markup extension to mix two SolidColorBrushes together to produce a new SolidColorBrush.
    /// </summary>
    [MarkupExtensionReturnType(typeof(SolidColorBrush))]
    public class MixedColorBrush : MarkupExtension, INotifyPropertyChanged
    {
        /// <summary>
        /// The foreground mix color; defaults to white.  
        /// If not changed, the result will always be white.
        /// </summary>
        private SolidColorBrush foreground = Brushes.White;
        /// <summary>
        /// The background mix color; defaults to black.  
        /// If not set, the result will be the foreground color.
        /// </summary>
        private SolidColorBrush background = Brushes.Black;
        /// <summary>
        /// PropertyChanged event for WPF binding.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Gets or sets the foreground mix color.
        /// </summary>
        public SolidColorBrush Foreground
        {
            get 
            { 
                return this.foreground; 
            }
            set 
            { 
                this.foreground = value; 
                this.NotifyPropertyChanged("Foreground"); 
            }
        }
        
        /// <summary>
        /// Gets or sets the background mix color.
        /// </summary>
        public SolidColorBrush Background
        {
            get 
            { 
                return this.background; 
            }
            set 
            { 
                this.background = value; 
                this.NotifyPropertyChanged("Background"); 
            }
        }
        /// <summary>
        /// Returns a SolidColorBrush that is set as the value of the 
        /// target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">Object that can provide services for the markup extension.</param>
        /// <returns>The object value to set on the property where the extension is applied.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (this.foreground != null && this.background != null)
            {
                // Create a new brush as a composite of the old ones
                // This does simple non-perceptual additive color, e.g 
                // blue + red = magenta, but you can swap in a different
                // algorithm to do subtractive color (red + yellow = orange)
                return new SolidColorBrush(this.foreground.Color + this.background.Color);
            }
            // If either of the brushes was set to null, return an empty (white) brush.
            return new SolidColorBrush();
        }
        /// <summary>
        /// Raise the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property which has changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
