    internal class ContainerSpecimenBuilder : ISpecimenBuilder
    {
        private readonly IContainer container;
    
        public ContainerSpecimenBuilder(IContainer container)
        {
            this.container = container;
        }
    
        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;
    
            if (t == null)
                return new NoSpecimen(request);
    
            var result = this.container.ResolveOptional(t);
            return result ?? new NoSpecimen(request);
        }
    }
