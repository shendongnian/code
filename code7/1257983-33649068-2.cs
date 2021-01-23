    public class RelaxedSeededFactory<T> : ISpecimenBuilder
    {
        private readonly Func<T, T> create;
    
        public RelaxedSeededFactory(Func<T, T> factory)
        {
            this.create = factory;
        }
    
        public object Create(object request, ISpecimenContext context)
        {
            if (request.Equals(typeof(T)))
            {
                return this.create(default(T));
            }
            var seededRequest = request as SeededRequest;
    
            if (seededRequest == null)
            {
                return new NoSpecimen(request);
            }
    
            if (!seededRequest.Request.Equals(typeof(T)))
            {
                return new NoSpecimen(request);
            }
    
            if ((seededRequest.Seed != null)
                && !(seededRequest.Seed is T))
            {
                return new NoSpecimen(request);
            }
    
            var seed = (T)seededRequest.Seed;
    
            return this.create(seed);
        }
    }
