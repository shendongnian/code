    public class PriceVarianceSupersetDisplayData
    {
        public String ShortName { get; set; }
        public String ItemCode { get; set; }
        public String Description { get; set; }
    
        public override bool Equals(object obj)
        {
            var pv = obj as PriceVarianceSupersetDisplayData;
    
            if (pv == null)
                return false;
    
            return this.ShortName == pv.ShortName
                && this.ItemCode == pv.ItemCode
                && this.Description == pv.Description;
        }
    
        public override int GetHashCode()
        {
            return 0;
        }
    }
    Func<PriceVarianceData, PriceVarianceSupersetDisplayData> selector =
                    (p => new PriceVarianceSupersetDisplayData()
                    {
                        ShortName = p.ShortName,
                        ItemCode = p.ItemCode,
                        Description = p.Description
                    });
    
    List<PriceVarianceSupersetDisplayData> results = 
            craftworksPVDList.Concat(chophousePVDList)
                            .Concat(gordonbierschPVDList)
                            .Concat(oldchicagoPVDList)
                            .Concat(oldchifranchisePVDList)
                            .Concat(rockbottomPVDList).Select(selector).Distinct().ToList();
