    public static class Enums
    {
        public static int GetMaxValue<T>() where T : struct
        {
            return Enum.GetValues(typeof (T)).Cast<int>().Sum();
        }
        public static int GetTotalCount<T>() where T : struct
        {
            return Enum.GetValues(typeof (T)).Cast<int>().Count(e => e > 0);
        }
        public static int GetFlagCount<T>(this T mask) where T : struct
        {
            int result = 0, value = (int) (object) mask;
            while (value != 0)
            {
                value = value & (value - 1);
                result++;
            }
            return result;
        }
        public static IEnumerable<T> Split<T>(this T mask)
        {
            int maskValue = (int) (object) mask;
            foreach (T flag in Enum.GetValues(typeof (T)))
            {
                int flagValue = (int) (object) flag;
                if (0 != (flagValue & maskValue))
                {
                    yield return flag;
                }
            }
        }
    }
