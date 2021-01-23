    public static class ClaimExtensions
    {
        public static object ValueAsValueType(this Claim claim)
        {
            switch (claim.ValueType)
            {
                case ClaimValueTypes.Double:
                    return double.Parse(claim.Value);
                case ClaimValueTypes.String:
                    return claim.Value;
                default:
                    throw new Exception(string.Format("Unhandled ClaimValueType {0} in ClaimExtensions.ValueAsValueType()", claim.ValueType));
            }
        }
        public static List<Claim> ToClaims(this Dictionary<string, object> payload)
        {
            return payload.Select(x =>
            {
                string valueType;
                var value = x.Value;
                if (x.Value is double || x.Value is decimal)
                    valueType = ClaimValueTypes.Double;
                else if (x.Value is string)
                    valueType = ClaimValueTypes.String;
                else
                    throw new Exception(string.Format("Unhandled type of Claim Value {0} in ClaimExtensions.ToClaims()", value.GetType()));
                return new Claim(x.Key, x.Value.ToString(), valueType);
            }).ToList();
        } 
    }
