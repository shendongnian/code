    public class BillCycleConverter : ITypeConverter<data.BillCycle, domain.BillCycle>
    {
        public domain.BillCycle Convert(ResolutionContext context)
        {
            context.Engine.Map<X, Y>...
        }
    }
