    private static object CoerceSelectionStart(DependencyObject d, object value)
    {
            Slider slider = (Slider)d;
            double selection = (double)value;
 
            double min = slider.Minimum;
            double max = slider.Maximum;
 
            if (selection < min)
            {
                return min;
            }
            if (selection > max)
            {
                return max;
            }
            return value;
        }
