    public class RiskManagementQueryValueObject
        {
            public string accountNo { get; set; }
            public string mainSalesPerson { get; set; }
            public string accountName { get; set; }
            public string ledgerBalance { get; set; }
    
            [DeserializeAs(Name = "T+3")]
            public string T3 { get; set; }
    
            [DeserializeAs(Name = "T+4")]
            public string T4 { get; set; }
    
            [DeserializeAs(Name = "T+5 and Above")]
            public string T5_and_Above { get; set; }
            public string riskRatedPortfolioValue { get; set; }
            public string exposure { get; set; }
            public string costToFirm { get; set; }
            public string incomeToFirm { get; set; }
    
            [DeserializeAs(Name = "costToIncome(%)")]
            public string costToIncome { get; set; }
    
            [DeserializeAs(Name = "exposure(%)")]
            public string exposure_per { get; set; }
    
            [DeserializeAs(Name = "O/S Balance")]
            public string OS_Balance { get; set; }
        }
