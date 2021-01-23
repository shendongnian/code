    public class NegativeRegexRouteConstraint : IRouteConstraint
    {
        private readonly string _pattern;
        private readonly Regex _regex;
        public NegativeRegexRouteConstraint(string pattern)
        {
            _pattern = pattern;
            _regex = new Regex(pattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (parameterName == null)
                throw new ArgumentNullException("parameterName");
            if (values == null)
                throw new ArgumentNullException("values");
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                string valueString = Convert.ToString(value, CultureInfo.InvariantCulture);
                return !_regex.IsMatch(valueString);
            }
            return true;
        }
    }
