		/// <summary>
		/// Converts the color to an Argb color
		/// </summary>
		/// <param name="color">Color to convert</param>
		/// <returns>The Argb color</returns>
		public static int ToArgb(int color)
		{
			int Argb = (color >> 16) | (color & 0xFF) << 16 | (color & 0x00FF00);
			return Argb;
		}
		/// <summary>
		/// Converts the color to a MSO Color
		/// </summary>
		/// <param name="Argb">Color to convert</param>
		/// <returns>The MSO color</returns>
		public static int ToMsoColor(int Argb)
		{
			Argb &= 0xFFFFFF;
			int color = (Argb >> 16) | (Argb & 0xFF) << 16 | (Argb & 0x00FF00);
			return color;
		}
