        /// <summary> 
        /// Callback for changes to the Number property 
        /// </summary>
    private static void OnNumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var tb = (NumberControl) d;
        if (tb.Number != tb.Text)
        {
            tb.Text = tb.Number;
        }
        if (tb.Number == null)
        {
            tb.SetValue(NumberProperty, null);
        }
    }
