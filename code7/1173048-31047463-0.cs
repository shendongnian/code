    private List<Dictionary<String, Object>> ValidateScenarioProductItemData(List<Dictionary<String, Object>> pList)
    {
        var tPeriods = new List<dynamic>();
        var tCycleProductItemSales = new List<dynamic>();
        foreach (var tItem in pList.Where(x=>!string.IsNullOrEmpty(x["IsInternal"].ToString())))
        {
            var i = 0;
            foreach (var item in tPeriods)
            {
                i++;
                var tHasSails = tCycleProductItemSales.Where(CPIS => CPIS.CycleId == Convert.ToInt32(tItem["CycleId"].ToString()) && CPIS.ProductItemId == Convert.ToInt32(tItem["ProductItemId"].ToString()) && CPIS.PeriodId == Convert.ToInt32(item.Id.ToString()));
                if (!tHasSails.Any())
                {
                    tItem[string.Format("Datasource{0}Id", i)] = 0;
                }
            }
        }
        return pList;
    }
