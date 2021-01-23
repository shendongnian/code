    /// <summary>
    /// The kind of gesture.
    /// </summary>
    public enum GestureKind : uint
    {
        /// <summary>
        /// The beginning of a gesture operation.
        /// </summary>
        Begin = 1,
        /// <summary>
        /// The end of a gesture operation.
        /// </summary>
        End = 2,
        /// <summary>
        /// A pan gesture.
        /// </summary>
        Pan = 4,
        /// <summary>
        /// A scroll gesture.
        /// </summary>
        Scroll = 8,
        /// <summary>
        /// A hold gesture.
        /// </summary>
        Hold = 9,
        /// <summary>
        /// A select gesture.
        /// </summary>
        Select = 10,
        /// <summary>
        /// A double-select gesture.
        /// </summary>
        DoubleSelect = 11,
        /// <summary>
        /// Direct manipulation.
        /// </summary>
        DirectManipulation = 12,
    }
