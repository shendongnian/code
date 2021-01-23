      private struct ShippingCost
      {
          public int MinWeight;
          public int MaxWeight;
          public decimal Cost;
          public ShippingCost(int min, int max, decimal cost)
          {
             MinWeight = min;
             MaxWeight = max;
             Cost = cost;
          }
      }
      private List<ShippingCost> Costs = new List<ShippingCost>
      {
          new ShippingCost(0, 2, 3.69m),
          new ShippingCost(3, 4, 4.86m),
          new ShippingCost(5, 6, 5.63m),
          new ShippingCost(7, 8, 5.98m),
          new ShippingCost(9, 10, 6.28m),
          new ShippingCost(11, 30, 15.72m),
      };
      // Choose shipping cost
      public decimal CalcShippingCost(int weight)
      {
          foreach (ShippingCost sc in Costs)
          {
              if (weight >= sc.MinWeight && weight <= sc.MaxWeight)
                  return sc.Cost;
          }
          return 0.00m;     // default cost
      }
