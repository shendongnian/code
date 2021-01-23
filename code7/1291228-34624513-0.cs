    public static class Constants
    {
        public const double UninitializedFloat = float.MinValue;
        public static bool IsUninitialized(this float value)
        {
            return value == UninitializedFloat;
        }
    }
    public class SeatDefinition
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate)]
        [DefaultValue(Constants.UninitializedFloat)]
        public float r3_value { get; set; } // Note: this could be 0, but it shouldn't be assumed to be 0 if undefined
    }
