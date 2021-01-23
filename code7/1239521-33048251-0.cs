    public static class StringExt
    {
        public static bool IsSamePathAs(this string @this, string other)
        {
            if (@this == null)
                return other == null;
            if (object.ReferenceEquals(@this, other))
                return true;
            // add other checks
            return @this.Equals(other, StringComparison.OrdinalIgnoreCase);
        }
    }
