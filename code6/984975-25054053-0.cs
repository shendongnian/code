      public T Magic
        {
            get { return _magic; }
            set
            {
                if (FuncEvaluate != null)
                {
                    if (!FuncEvaluate(value, _magic))
                    {
                        _magic = value;
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
