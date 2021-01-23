    public List<decimal> getTotalSellingPrice(int costSheetID)
    {
        List<decimal> totalSellingPrice = new List<decimal>();
        List<object> toms = getToms(costSheetID);
        int j = 0,
            tomsCount = toms.Count;
        foreach (var i in getMarkupPrice(costSheetID))
        {
            if(j >= tomsCount )
                break;
            totalSellingPrice.Add(Math.Round(i + Convert.ToDecimal(toms[j])));
            j++;
        }
        return totalSellingPrice;
    }
