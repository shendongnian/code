    public static class BinaryConverter
        {
            public static BitArray ToBinary(this int numeral)
            {
                return new BitArray(new[] { numeral });
            }
            public static int ToNumeral(this BitArray binary)
            {
                if (binary == null)
                    throw new ArgumentNullException("binary");
                if (binary.Length > 32)
                    throw new ArgumentException("must be at most 32 bits long");
                var result = new int[1];
                binary.CopyTo(result, 0);
                return result[0];
            }
            public static BitArray Take (this BitArray current, int length )
            {
                if (current.Length < length)
                    throw new Exception("Invalid length parameter");
                List<bool> taken = new List<bool>();
                for (int i = 0; i < length; i++)
                        taken.Add(current.Get(i));
                return new BitArray(taken.ToArray());
            }
            public static BitArray Shift (this BitArray current, int length )
            {
                if (current.Length < length)
                    throw new Exception("Invalid length parameter");
                List<bool> shifted = new List<bool>();
                for (int i = 0; i < current.Length - length; i++)
                    shifted.Add(current.Get(length + i));
                return new BitArray(shifted.ToArray());
            }
            public static BitArray FitSize (this BitArray current, int size)
            {
                List<bool> bools = new List<bool>() ;
                bools = bools.InitBoolArray(size);
                for (int i = 0; i < current.Count; i++)
                        bools[i] = current.Get(i) ;
                return new BitArray(bools.ToArray());
            }
            public static List<bool> InitBoolArray(this List<bool> current, int size)
            {
                List<bool> bools = new List<bool> ();
                for (int i = 0; i < size; i++)
                    bools.Add(false);
                return bools ;
            }
        }
