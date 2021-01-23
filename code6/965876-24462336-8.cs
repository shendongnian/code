      static SplittedMoney SplitMoney(decimal money)
      {
            var totalCents = (int)(money * 100);
            int dollars = (int)(totalCents / 100);
            int cents = (int)(totalCents % 100);
            return new SplittedMoney(dollars, cents);
      }
