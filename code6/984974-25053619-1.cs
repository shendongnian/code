     public T Magic
        {
            get { return _magic; }
            set
            {
                // Compiler error here!
                if (!value.Equals(_magic))
                    _magic = value;
            }
        }
