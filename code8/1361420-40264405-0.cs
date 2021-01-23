    /// <summary>
    ///     Gets the previous page, if it was an instance of the "MyPrevious.aspx" page.
    /// </summary>
    /// <remarks>This access is used for the access to data from the "MyPrevious.aspx" page.</remarks>
    /// <value>
    ///     The previous page, if it was an instance of the "MyPrevious.aspx" page, null otherwise.
    /// </value>
    private MyPrevious CheckedPreviousPage {
        get {
            if (base.PreviousPage != null) {
                if (base.PreviousPage is MyPrevious) {
                    return PreviousPage;
                }
            }
            return null;
        }
    }
