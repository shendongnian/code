    public class CostAccouting
    {
            public int Id { get; set; }
            public decimal? Total { get; set; }
            public int CostCategoryId { get; set; }
            public CostCategory CostCategory { get; set; }
    }
