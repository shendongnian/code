        static unsafe long FindLastSetBitUnsafe(BitArray array)
        {
            int[] intArray = (int[])array.GetType().GetField("m_array", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(array);
            fixed (int* buffer = intArray)
            {
                for (var i = intArray.Length; i >= 0; i--)
                {
                    var b = buffer[i];
                    if (b != 0)
                    {
                        var pos = (i << 5) + 31;
                        for (int bit = 31; bit >= 0; bit--)
                        {
                            if ((b & (1 << bit)) != 0)
                                return pos;
                            pos--;
                        }
                        return pos;
                    }
                }
            }
            return -1;
        }
