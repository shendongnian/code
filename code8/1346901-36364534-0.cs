    public static class BoolExtensions
    {
        public static string ToString(this bool boolean, string valueIfTrue, string valueIfFalse)
        {
            return boolean ? valueIfTrue : valueIfFalse;
        }
    }
