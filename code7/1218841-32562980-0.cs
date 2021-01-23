    public class FilteringRelay : ISpecimenBuilder
    {
        private readonly IRequestSpecification _filter;
        public FilteringRelay(IRequestSpecification filter)
        {
            _filter = filter;
        }
        public object Create(object request, ISpecimenContext context)
        {
            return _filter.IsSatisfiedBy(request)
                ? context.Resolve(request)
                : new NoSpecimen(request);
        }
    }
