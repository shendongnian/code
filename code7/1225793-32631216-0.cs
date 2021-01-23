    set
    {
          if (!string.IsNullOrEmpty(Name))
          {
                name = value;
          }
          else
          {
                throw new ArgumentException("Name cannot be null or empty string", "Name");
          }
    }
