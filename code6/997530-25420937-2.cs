    public List<decimal> getTotalSellingPrice(int costSheetID) 
    {
        List<decimal> totalSellingPrice = new List<decimal>();
        foreach (var i in getMarkupPrice(costSheetID))
        {
          foreach (var m in getToms(costSheetID))
          {
              totalSellingPrice.Add(Math.Round(i + m));
          }
        }
        return totalSellingPrice;
    }
