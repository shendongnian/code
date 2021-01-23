    public class HTDataGridTemplateColumn : DataGridTemplateColumn
    {
        /// <summary>
        /// Declare how the &lt;see cref="DataGridColumn"/&gt; should be resized. 
        /// </summary>
        public ResizeModeOptions ResizeMode
        {
            get { return (ResizeModeOptions)GetValue(ResizeModeProperty); }
            set { SetValue(ResizeModeProperty, value); }
        }
        public static readonly DependencyProperty ResizeModeProperty = DependencyProperty.Register("ResizeMode", typeof(ResizeModeOptions), typeof(HTDataGridTemplateColumn), new PropertyMetadata(ResizeModeOptions.None));
       
        /// <summary>
        /// Declare how the <see cref="DataGridColumn"/> should be resized.
        /// </summary>
        public enum ResizeModeOptions
        {
            /// <summary>
            /// No resize animation/action will be done.
            /// </summary>
            None,
            /// <summary>
            /// The width is adjusted.
            /// </summary>
            Fit,
            /// <summary>
            /// The width is streched.
            /// </summary>
            Stretch
        }
    }
