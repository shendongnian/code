    public List<decimal> getTotalSellingPrice(int costSheetID) 
    {
        List<decimal> totalSellingPrice = new List<decimal>();
        decimal bothMarkupAndToms = 0;
        foreach (var i in getMarkupPrice(costSheetID)) 
        {
          bothMarkupAndToms = i;
          foreach (var m in getToms(costSheetID)) 
          {
              bothMarkupAndToms += m;                      
          }
          totalSellingPrice.Add(Math.Round(bothMarkupAndToms));   
        }
        return totalSellingPrice;
    }
