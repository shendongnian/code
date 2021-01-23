    public static List<string> ToMemberList(this Enum enumerationValue)
            {
                var type = enumerationValue.GetType();
                return Enum.GetValues(type).Cast<object>().Select(x => x.ToString()).ToList();
            }
 
