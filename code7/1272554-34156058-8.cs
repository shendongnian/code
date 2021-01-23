    [Flags]
    public enum GestureState : uint
    {
        /// <summary>
        /// The gesture has no associated state
        /// </summary>
        None = 0,
        /// <summary>
        /// The gesture is the beginning of pan gesture
        /// </summary>
        Begin = 1,
        /// <summary>
        /// The gesture is the end of a pan gesture that will transition into a scroll gesture
        /// </summary>
        Inertia = 2,
        /// <summary>
        /// The gesture is the end of a pan gesture
        /// </summary>
        End = 4
    }
