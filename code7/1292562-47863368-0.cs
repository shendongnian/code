        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);
        void ChangeSelectColour(Color color)
        {
            const int COLOR_HIGHLIGHT = 13;
            const int COLOR_HIGHLIGHTTEXT = 14;
            // You will have to set the HighlightText colour if you want to change that as well.
            
            //array of elements to change
            int[] elements = { COLOR_HIGHLIGHT };
            List<uint> colours = new List<uint>();
            colours.Add((uint)ColorTranslator.ToWin32(color));
            
            //set the desktop color using p/invoke
            SetSysColors(elements.Length, elements, colours.ToArray());
        }
