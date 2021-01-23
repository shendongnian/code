    /// <summary>
    /// Class that contain the names of arrays used to save settings.
    /// </summary>
    private class ArrayNamesList : List<string>
    {
        /// <summary>
        /// Adds an array name to the list.
        /// </summary>
        /// <param name="GlobalVariableName">Name of the array variable.</param>
        internal new void Add(string GlobalVariableName)
        {
            base.Add(GlobalVariableName);
        }
    }
