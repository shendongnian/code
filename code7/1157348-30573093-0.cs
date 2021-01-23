    public static class ArrayExtensions 
    {
      // Getter using underlying array
      public static T GetValueAt<T>(this ArraySegment<T> array, int index)
      { // No safe checks here, would recommend them in production though
        return array.Array[array.Offset + index];
      }
      // Setter using underlying array
      public static void SetValueAt<T>(this ArraySegment<T> array, int index, T value)
      { // maybe we should check that the calculated index is valid? Or just blow up?
        array.Array[array.Offset + index] = value;
      }
    }
