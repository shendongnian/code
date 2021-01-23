    public class TextBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            var pi = request as PropertyInfo;
            if (pi == null)
                return new NoSpecimen(request);
            if (pi.PropertyType == typeof(string))
                return pi.Name;
            if (pi.PropertyType == typeof(IList<string>) || pi.PropertyType == typeof(List<string>))
            {
                var tmps = (List<string>)context.Resolve(typeof(List<string>));
                for (var n = 0; n != tmps.Count; ++n)
                    tmps[n] = pi.Name + n.ToString(CultureInfo.InvariantCulture);
                return tmps;
            }
            return new NoSpecimen(request);
        }
    }
