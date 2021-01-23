    public static class SafeConvert
    {
        public static int ToInt32(object number)
        {
            try
            {
                // if (TypeValidator.IsInt(number)) // If you want to check type before cast to avoid any potential exceptions
                return Convert.ToInt32(number);
            }
            catch
            { // Log you exception}
                return 0;
            }
        }
    }
