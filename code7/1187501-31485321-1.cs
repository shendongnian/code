      void AddCouple<T>(this List<T> list) where T:new()
      {
          list.Add(new T());
          list.Add(new T());
      }
