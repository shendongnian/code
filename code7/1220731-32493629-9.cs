    private static int BinarySearch(Array array, object value)
        {
            ulong[] ulArray = new ulong[array.Length];
            for (int i = 0; i < array.Length; ++i)
                ulArray[i] = Enum.ToUInt64(array.GetValue(i));
 
            ulong ulValue = Enum.ToUInt64(value);
 
            return Array.BinarySearch(ulArray, ulValue);
        }
