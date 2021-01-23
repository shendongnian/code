    public class EmailAddressStringsGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (IsEnumerableOfStringPropertyOrParameterNamedEmail(request))
            {
                return CreateManyEmailAddresses(context);
            }
            return new NoSpecimen();
        }
        static bool IsEnumerableOfStringPropertyOrParameterNamedEmail(object request)
        {
            return IsEnumerableOfStringPropertyNamedEmail(request) ||
                   IsEnumerableOfStringParameterNamedEmail(request);
        }
        static bool IsEnumerableOfStringPropertyNamedEmail(object request)
        {
            var property = request as PropertyInfo;
            return property != null &&
                   property.Name.ContainsIgnoringCase("email") &&
                   typeof(IEnumerable<string>).IsAssignableFrom(property.PropertyType);
        }
        static bool IsEnumerableOfStringParameterNamedEmail(object request)
        {
            var parameter = request as ParameterInfo;
            return parameter != null &&
                   parameter.Name.ContainsIgnoringCase("email") &&
                   typeof(IEnumerable<string>).IsAssignableFrom(parameter.ParameterType);
        }
        static IEnumerable<string> CreateManyEmailAddresses(ISpecimenContext context)
        {
            var addresses = (IEnumerable<MailAddress>) 
                context.Resolve(typeof(IEnumerable<MailAddress>));
            return addresses.Select(a => a.Address);
        }
    }
