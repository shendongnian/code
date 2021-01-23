		public static byte insertIntoPosition(byte number, int position, bool bit)
		{
			// converting the number to BitArray
			BitArray a = new BitArray (new byte[]{number});
			// shifting the bits to the left of the position
			for (int j = a.Count - 1; j > position; j--) {
				a.Set (j, a.Get (j - 1));
			}
			// setting the position bit
			a.Set (position, bit);
			// converting BitArray to byte again
			byte[] array = new byte[1];
			a.CopyTo(array, 0);
			return array[0];
		}
