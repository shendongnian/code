      static int SplitMoney(ref double money)
      {
            money = (int)(money * ONE_HUNDRED);
            int dollars = (int)(money / ONE_HUNDRED);
            int cents = (int)(money % ONE_HUNDRED);
            return cents;
      }
