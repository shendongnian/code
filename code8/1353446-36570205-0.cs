      public static class IntExtension
    {
        public static bool IsBool(this int number)
        {
            bool result = true;
            if (number == 0)
            {
                result = false;
            }
            return result;
        }
    }
