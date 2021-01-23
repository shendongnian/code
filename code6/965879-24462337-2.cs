      static Tuple<int,int> SplitMoney(double money)
      {
            var totalCents = (int)(money * ONE_HUNDRED);
            int dollars = (int)(money / ONE_HUNDRED);
            int cents = (int)(money % ONE_HUNDRED);
            return Tuple.Create(dollars,cents);
      }
