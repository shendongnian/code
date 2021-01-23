      public void Set(T Deposit)
        {
            lock (key)
            {
                _Item -= Deposit/x;  x can take the value of zero
            }
        }
