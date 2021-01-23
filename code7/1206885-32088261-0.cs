    /// <summary>
    /// Set the column width from the content of the range.
    /// Note: Cells containing formulas are ignored if no calculation is made.
    ///       Wrapped and merged cells are also ignored.
    /// </summary>
    /// <param name="MinimumWidth">Minimum column width</param>
    /// <param name="MaximumWidth">Maximum column width</param>
    public void AutoFitColumns(double MinimumWidth, double MaximumWidth)
