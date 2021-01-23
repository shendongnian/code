    public static IEnumerable<BusRow> Interleave(List<BusRow> rowItems, List<BusRow> subTotalItems)
    {
       for(int i = 0 ; i < rowItems.Count; ++i)
       {
         yield return rowItems[i];
         if(i > 0 && rowItems[i].BusinessTypeCode != rowItems[i-1].BusinessTypeCode)
         {
           yield return subTotalItems.Single(x => x.BusinessTypeCode == rowItems[i-1].BusinessTypeCode);
         }
       }
       yield return subTotalItems.Single(x => x.BusinessTypeCode == rowItems[rowItems.Count-1].BusinessTypeCode);
    }
