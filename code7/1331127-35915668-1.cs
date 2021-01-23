    /// <summary>
    /// User authorization level.
    /// </summary>
    public enum UserAuthorizationLevel
    {
        /// <summary>
        /// Only visual inspection is allowed (the first lower level).
        /// </summary>
        Inspection = 0,
        /// <summary>
        /// Some settings in apparatus are allowed (the second level).
        /// </summary>
        SettingDeviceParametersApplied = 1,
        /// <summary>
        /// Some more setting in apparatus are allowed than in the second level (the third level).
        /// </summary>
        Maintenance = 2,
        /// <summary>
        /// Apparatus manufacturer level - full access is allowed (the highest level).
        /// </summary>
        Manufacturer = 3
    }
