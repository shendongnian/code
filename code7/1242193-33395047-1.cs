    public static class DbPropertyValueExtensions
    {
        public static Dictionary<string, object> ValuesToValuesDictionary(this DbPropertyValues vals)
        {
            var retVal = new Dictionary<string, object>();
            foreach (var propertyName in vals.PropertyNames)
            {
                if (!retVal.ContainsKey(propertyName))
                {
                    retVal.Add(propertyName, vals[propertyName]);
                }
            }
            return retVal;
        }
    }
