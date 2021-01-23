    public class StreetNameBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null || pi.Name != "StreetName" || pi.PropertyType != typeof(string))
                return new NoSpecimen();
            var sn = context.Resolve(typeof(StreetName));
            return (string)(StreetName)sn;
        }
    }
