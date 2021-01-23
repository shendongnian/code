    Unhandled Exception: System.ArrayTypeMismatchException: Source array type cannot be assigned to destination array type.
       at System.Array.Copy(Array sourceArray, Int32 sourceIndex, Array destinationArray, Int32 destinationIndex, Int32 length, Boolean reliable)
       at System.SZArrayHelper.CopyTo[T](T[] array, Int32 index)
       at System.Collections.Generic.List`1..ctor(IEnumerable`1 collection)
       at System.Linq.Enumerable.ToList[TSource](IEnumerable`1 source)
       at Test.Main()
