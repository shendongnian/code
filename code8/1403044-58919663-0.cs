    public static class GenericExtension
    {
        /// <summary>
        /// Returns the caller method name, mainly used to log debug message.
        /// </summary>
        /// <param name="_"></param>
        /// <param name="caller"></param>
        /// <returns></returns>
        public static string GetMethodName<T>(this T _, [CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
