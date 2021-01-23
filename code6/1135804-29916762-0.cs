    public class PropertyBuilder : ISpecimenBuilder
    {
        public object Create(object request,
            ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi != null)
            {
                if (pi.IsDefined(typeof (DependencyAttribute)))
                    return context.Resolve(pi.PropertyType);
                else
                    return new OmitSpecimen();
            }
            return new NoSpecimen(request);
        }
    }
    fixture.Customizations.Add(new PropertyBuilder());
