    public class ForeignKeyConstraintNameConvention
    : IHasManyConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.Key.ForeignKey(
             string.Format("{1}_FK",instance.EntityType.Name));
        }
    }
