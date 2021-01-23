    public class SalesinvDetsMonthCombined
    {
      public string Month {get; set;}
      public string Month2 {get; set;}
      public int Amount {get; set;}
      public int Amount2 {get; set;}
    }
    int totalCount = SalesinvDetsMonth.Count;
    
    List<SalesinvDetsMonthCombined> result = new List<SalesinvDetsMonthCombined>();
    
    for (int index=0, index < totalCount; index ++)
    {
      result.Add(new SalesinvDetsMonthCombined
                    ( Month = SalesinvDetsMonthList[index].Month,
                      Month2 = SalesinvDetsMonth2List[index].Month2,
                      Amount = SalesinvDetsMonthList[index].Amount,
                      Amount2 = SalesinvDetsMonth2List[index].Amount2
                    ));
    }
