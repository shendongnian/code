    set
    {
          if (!string.IsNullOrEmpty(value))
          {
                name = value;
          }
          else
          {
                throw new ArgumentException("Name cannot be null or empty string", "Name");
          }
    }
