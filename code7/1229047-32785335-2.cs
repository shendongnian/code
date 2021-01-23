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
