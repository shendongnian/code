    /// <summary>
    /// A store to pass data between pages.
    /// </summary>
    public class PersistentData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersistentData"/> class.
        /// </summary>
        public PersistentData()
        {
            this.ExportPathActive = false;
        }
        /// <summary>
        /// Gets or sets a value indicating whether [export path active].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [export path active]; otherwise, <c>false</c>.
        /// </value>
        public bool ExportPathActive { get; set; }
    }
