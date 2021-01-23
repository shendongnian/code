    public class ForeignKeyNotPkIndexConvention : ForeignKeyIndexConvention
    {
        public override void Apply(AssociationType item, DbModel model)
        {
            if (item.AssociationEndMembers.Any(x => x.RelationshipMultiplicity == RelationshipMultiplicity.Many))
                base.Apply(item, model);
        }
    }
