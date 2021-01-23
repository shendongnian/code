    /// <summary>
    /// Types of limits that can be applied to a table, view, or table-value function query.
    /// </summary>
    /// <remarks>Databases are expected to provide their own enumeration that represents a subset of these options.</remarks>
    [Flags]
    public enum LimitOptions
    {
        /// <summary>
        /// No limits were applied.
        /// </summary>
        None = 0,
        /// <summary>
        /// Returns the indicated number of rows with optional offset
        /// </summary>
        Rows = 1,
        /// <summary>
        /// Returns the indicated percentage of rows. May be applied to TableSample
        /// </summary>
        Percentage = 2,
        /// <summary>
        /// Adds WithTies behavior to Rows or Percentage
        /// </summary>
        WithTies = 4,
        /// <summary>
        /// Returns the top N rows. When there is a tie for the Nth record, this will cause it to be returned. 
        /// </summary>
        RowsWithTies = Rows | WithTies,
        /// <summary>
        /// Returns the top N rpercentage of ows. When there is a tie for the Nth record, this will cause it to be returned. 
        /// </summary>
        PercentageWithTies = Percentage | WithTies,
