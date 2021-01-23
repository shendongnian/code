    public T Magic
        {
            get { return _magic; }
            set
            {
                // Compiler error here!
                  if (!EqualityComparer<T>.Default.Equals(_magic, value))
                    _magic = value;
            }
        }
