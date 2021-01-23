    public List<decimal> getTotalSellingPrice(int costSheetID) 
    {
        List<decimal> totalSellingPrice = new List<decimal>();
        decimal bothMarkupAndToms = 0;
        List<decimal> markupPriceList = getMarkupPrice(costSheetID);
        List<decimal> tomsList = getToms(costSheetID);
        for(int i = 0 ; i < tomsList.size() ; i++)
        {
          totalSellingPrice.Add(Math.Round(markupPriceList[i] + tomsList[i]));   
        }
        return totalSellingPrice;
    }
