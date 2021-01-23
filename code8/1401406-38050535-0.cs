    // Make sure to add these first:
    using System.Linq;
    using System.Collections.Generic;
    private bool arrayMaking(int[] array1, int[] array2, int value, out int[] arrays)
    {
        List<int> array = new List<int>();
		array.AddRange(array1);
		array.AddRange(array2);
		array.Add(value);
        arrays = array.ToArray();
        return true;
    }
