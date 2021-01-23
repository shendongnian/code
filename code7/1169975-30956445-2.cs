    public IEnumerator GetEnumerator()
    {
      for(int i = 0 ; i < array.Length; ++i)
      {
          yield return array[i];
      }
    }
