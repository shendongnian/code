            public static string ToIntegers<T>(this IEnumerable<object> values) where T : struct
            {
                return values?.Select(x => {
                    T enumValue;
                    return Enum.TryParse(x.ToString(), out enumValue) ? Convert.ToInt32(enumValue).ToString() : null;
                })
                .Where(x => x != null)
                .Aggregate((s1, s2) => s1 + "," + s2);
            }
