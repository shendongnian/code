    public static class ImageSourceHelper
    {
        public static string CrossPlatformImage(string resource)
        {
            return Device.OnPlatform(string.Concat("resources", resource), resource, string.Concat("resources", resource));
        }
    }
