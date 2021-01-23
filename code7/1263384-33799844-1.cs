    // Sorts a list using IComparable<T>
    public static void Sort(this List<T> list)
    {
       // Worst sorting algorithm ever
       for (int i = 0; i < list.Count; ++i)
       {
          for (int j = 0; j < list.Count; ++j)
          {
              // Assumes that type T implements IComparable<T>
              IComparable<T> first  = (list[i] as IComparable<T>);
              IComparable<T> second = (list[j] as IComparable<T>);
              if (first.CompareTo(second) > 0)
              {
                  // wrong order
                  Swap(list, i, j);
              }
          }
       }
    }
