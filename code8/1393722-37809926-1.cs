       public KeyCountMap(Type dictionaryType)
       {
          if (!typeof(IDictionary<T, MutableInt>).IsAssignableFrom(dictionaryType))
          {
              throw new ArgumentException("Type must be a IDictionary<T, MutableInt>", nameof(dictionaryType));
          }
          map = (IDictionary<T, MutableInt>)Activator.CreateInstance(dictionaryType);
       }
    }  
