        public static IEnumerable<int> Utf32CodePoints(string s, int index)
        {
            for (int length = s.Length; index < length; index++)
            {
                yield return char.ConvertToUtf32(s, index);
                if (char.IsSurrogatePair(s, index))
                    index++;
            }
        }
        public static IEnumerable<KeyValuePair<int, int>> Utf32IndexedCodePoints(string s, int index)
        {
            for (int length = s.Length; index < length; index++)
            {
                yield return new KeyValuePair<int, int>(index, char.ConvertToUtf32(s, index));
                if (char.IsSurrogatePair(s, index))
                    index++;
            }
        }
