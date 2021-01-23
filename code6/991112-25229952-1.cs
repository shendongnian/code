    public class FieldSummaryMap: ClassMap<FieldSummaryRow>
    {
        public FieldSummaryMap()
        {
            Id(x => x.Id);
            Component(x => x.A, c =>
            {        
                c.Map(x => x.value).Column("valueA").Access.CamelCaseField();
                c.Map(x => x.description).Column("descriptionA").Access.CamelCaseField();
            }
            Component(x => x.B, c =>
            ...
        }
    }
