    public static IEnumerable<T> InsertAndShift(T[] array, T value, int index)
    {
         //Omitting argument checks: null, range, etc.
         for (int i = 0; i < array.Count - 1; i++)
         {
              if (i < index)
              {
                  yield return array[i];
              }
              else if (i == index)
              {
                  yield return input;
              }
              else
              {
                  yield return array[i - 1];
              }
         }
    }
    var shiftedArray = array.InsertAndShift(0, 3).ToArray();
