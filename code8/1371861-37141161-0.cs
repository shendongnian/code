    internal class LocalizeHelper
    {
        public enum LocalizeStringsEnum
        {
            UnsupportedFeature
        }
        public static string GetText(LocalizeStringsEnum key)
        {
            switch (key)
            {
                case LocalizeStringsEnum.UnsupportedFeature:
                    return Resources.UnsupportedFeature;
                default:
                    // Should never be raised unless a key is not defined in the enum.
                    throw new ArgumentOutOfRangeException("Unknown key provided");
            }
        }
