        const string Hebrew1 = "צבע אדום";
        const string Hebrew1ApparentFirstChar = "ם";
        static void TestHebrewConstantStringOrder() 
        {
            List<int> Hebrew1Utf32 = new List<int>(TextHelper.Utf32CodePoints(Hebrew1, 0));
            foreach (var codePoint in TextHelper.Utf32CodePoints(Hebrew1ApparentFirstChar, 0))
            {
                int index = Hebrew1Utf32.IndexOf(codePoint);
                Debug.WriteLine(string.Format("Index of U+{0:X8}:  {1}", codePoint, index));
            }
            Debug.WriteLine("Codepoints of " + Hebrew1);
            foreach (var pair in TextHelper.Utf32IndexedCodePoints(Hebrew1, 0))
            {
                string msg = string.Format("{0,7}: U+{1:X8}", pair.Key, pair.Value);
                Debug.WriteLine(msg);
            }
        }
