    I have worked out the solution myself. Following are the details
    Supposingly, I have entities and mappings for each database table. In one of the entities Lets say AnnualInformation entity (tableAnnual)
    I will create relationships of MonthlyInformation entity (tableMonthly), ShareValueInformation entity (tableSharevalue) and MiscDetails entity (tableMiscDetails)
    The code of AnnualInformation entity will look Like below :
    public class AnnualInformation
    {
        public virtual int Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual decimal AnnualAmount { get; set; }
        public virtual string AnnualCurrency { get; set; }
        public virtual MonthlyInformation MonthlyInformation { get; set; }
        public virtual ShareValueInformation ShareValueInformation { get; set; }
        public virtual MiscDetails MiscDetails { get; set; }
    }
    The corresponding mapping class will be as follows :
        
    public class AnnualInformationMap : ClassMap<AnnualInformation>
    {
        public AnnualInformationMap()
        {
            Table("tableAnnual");
            Id(x => x.CreationDate, "creationDate ");
            Map(x => x.Id, "Id");
            Map(x => x.AnnualAmount, "AnnualAmount");
            Map(x => x.AnnualCurrency, "AnnualCurrency");
            References(x => x.MonthlyInformation).Column("creationDate");
            References(x => x.ShareValueInformation).Column("creationDate");
            References(x => x.MiscDetails).Column("creationDate");
        }
    }
	Now, we need to retrieve the data from all these four database tables with Left Outer Join. Therefore we will work the solution as follows
	
	                    MonthlyInformation monthlyAlias = null;
                        ShareValueInformation shareAlias = null;
                        MiscDetails miscAlias = null;
                        // Create your db session...
                        using (session)
                        {
                            var result = session.QueryOver<AnnualInformation>()
                                         .JoinAlias(a => a.MonthlyInformation, () => monthlyAlias, JoinType.LeftOuterJoin)
                                         .JoinAlias(a => a.ShareValueInformation, () => shareAlias, JoinType.LeftOuterJoin)
                                         .JoinAlias(a => a.MiscDetails, () => miscAlias, JoinType.LeftOuterJoin)
                                         .SelectList(list => list
                                             .Select(x => x.Id)
                                             .Select(x => x.CreationDate)
                                             .Select(x => x.AnnualAmount)
                                             .Select(x => x.AnnualCurrency)
                                             .Select(() => monthlyAlias.MonthlyAmount)
                                             .Select(() => monthlyAlias.MonthlyCurrency)
                                             .Select(() => shareAlias.CurrentSharevalue)
                                             .Select(() => miscAlias.MarketValueAmount)
                                         ).Where(a => a.Id == 123456).
                                         List<object[]>();
                        }
	Here it is, the data that we were looking forward to is list of object stored in variable result, for completely unrelated entities. Thanks!!!
	
	
