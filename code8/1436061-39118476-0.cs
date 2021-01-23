    lock(_lockerObject)
    {
        // Do operations that modify _payments collection
        _payments.Add();//...
    }
        public decimal TotalChange
        {
            get
            {
                lock (_lockerObject)
                {
                    var change = (from IPayment payment in _payments where payment.Amount < 0 select payment.Amount).Sum();
                    var paid = (from IPayment payment in _payments select payment.Amount).Sum();
                }
                return paid <= Total && Total > 0 ? Math.Abs(change) : paid - Total;
            }
        }
