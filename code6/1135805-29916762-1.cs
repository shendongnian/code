    public class PropertyBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null)
            {
                if (pi.IsDefined(typeof (DependencyAttribute)))
                    return context.Resolve(pi.PropertyType);
                //"hey, don't set this property"
                return new OmitSpecimen();
            }
            //"i don't know how to handle this request - go ask some other ISpecimenBuilder"
            return new NoSpecimen(request);
        }
    }
    fixture.Customizations.Add(new PropertyBuilder());
