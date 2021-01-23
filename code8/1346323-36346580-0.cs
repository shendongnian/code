    public void displayCorrespondingTooltip<T>(T control, string tooltipText)
        {
           //For images
            if (control.GetType() == typeof(Image))
            {
                (control as Image).ToolTip = tooltipText;
            }
           //For Rectangles
            if (control.GetType() == typeof(Rectangle))
            {
                (control as Rectangle).ToolTip = tooltipText;
            }
        }
