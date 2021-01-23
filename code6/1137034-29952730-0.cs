        /// <summary>
        /// Returns how many bits are required to store the specified
        /// number of colors. Performs a Log2() on the value.
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public static int GetBitsNeededForColorDepth(byte colors) {
            return (int)Math.Ceiling(Math.Log(colors, 2));
        }
