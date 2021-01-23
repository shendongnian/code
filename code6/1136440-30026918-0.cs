    public class ForeignKeyConstraintNameConvention
    : IReferenceConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Key.ForeignKey("{0}_{1}_FK".AsFormat(
            instance.Member.Name, instance.EntityType.Name));
        }
    }
