    /// <summary>
    /// Calculates an approximation of the available caption width
    /// Depends on OS and theme
    /// </summary>
    /// <returns>Width</returns>
    private int CalcAvaliableCaptionWidth()
    {
        return
    	// Form width
    	Width
    	// Icon
    	- (Icon == null ? 0 : Icon.Width)
    	// Minimize button (26 on Win8)
    	- (MinimizeBox ? SystemInformation.CaptionButtonSize.Width : 0)
    	// Maximize button (26 on Win8)
    	- (MaximizeBox ? SystemInformation.CaptionButtonSize.Width : 0)
    	// Close button (45 on Win8)
    	- SystemInformation.CaptionButtonSize.Width;
    }
