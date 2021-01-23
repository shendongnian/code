    public static T[] ToEnumsArray<T>(this string stringValuesWithDelimeter) where T : struct
        {
            var result = new List<T>();
            if (!string.IsNullOrWhiteSpace(stringValuesWithDelimeter))
            {
                var arr = stringValuesWithDelimeter.Split(',');
                foreach (var item in arr)
                {
                    if (Enum.TryParse(item, true, out T enumResult))
                    {
                        result.Add(enumResult);
                    }
                }
            }
            return result.ToArray();
        }
