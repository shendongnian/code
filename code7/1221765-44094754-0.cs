     public static class EnumExtensions
     {
            public static bool InSet<T>(this T target, params T[] possibleValues) where T : struct 
            {
                return possibleValues.Contains(target);
            }
        }
