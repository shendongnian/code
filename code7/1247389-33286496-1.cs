      // One InputVO per datatype
      public Dictionary<Type, InputVOBase> AllInputs { get; private set; }
      // Return the VO for type T, or null
      public InputVO<T> GetInput<T>()
      {
          InputVOBase vo = AllInputs[typeof(T)];
          return (vo as InputVO<T>);
      }
