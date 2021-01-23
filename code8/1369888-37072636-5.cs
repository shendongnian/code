        static long FindLastSetBitReflection(BitArray array)
        {
            int[] intArray = (int[])array.GetType().GetField("m_array", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(array);
            for (var i = intArray.Length - 1; i >= 0; i--)
            {
                var b = intArray[i];
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
            return -1;
        }
