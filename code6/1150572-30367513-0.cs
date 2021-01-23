    public class PointCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new XBuilder());
            fixture.Customizations.Add(new YBuilder());
        }
        private class XBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var pi = request as ParameterInfo;
                if (pi == null ||
                    pi.Name != "x" ||
                    pi.Member.DeclaringType != typeof(Point))
                    return new NoSpecimen(request);
                return context.Resolve(
                    new RangedNumberRequest(typeof(double), -90d, 90d));
            }
        }
        private class YBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var pi = request as ParameterInfo;
                if (pi == null ||
                    pi.Name != "y" ||
                    pi.Member.DeclaringType != typeof(Point))
                    return new NoSpecimen(request);
                return context.Resolve(
                    new RangedNumberRequest(typeof(double), -180d, 180d));
            }
        }
    }
