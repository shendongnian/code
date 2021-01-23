    public class EmailAddressStringGenerator : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (IsStringPropertyOrParameterNamedEmail(request))
            {
                var address = (MailAddress)context.Resolve(typeof(MailAddress));
                return address.Address;
            }
            return new NoSpecimen();
        }
        static bool IsStringPropertyOrParameterNamedEmail(object request)
        {
            return IsStringPropertyNamedEmail(request) ||
                   IsStringParameterNamedEmail(request);
        }
        static bool IsStringPropertyNamedEmail(object request)
        {
            var property = request as PropertyInfo;
            return property != null &&
                   property.Name.ContainsIgnoringCase("email") &&
                   property.PropertyType == typeof(string);
        }
        static bool IsStringParameterNamedEmail(object request)
        {
            var parameter = request as ParameterInfo;
            return parameter != null &&
                   parameter.Name.ContainsIgnoringCase("email") &&
                   parameter.ParameterType == typeof(string);
        }
    }
