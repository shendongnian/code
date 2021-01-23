        public static IList ToList(this Type type, Enum[] valuesToSkip)
        {
            ArrayList enumList = new ArrayList();
            Array enumValues = Enum.GetValues(type);
            foreach (Enum value in enumValues)
            {
                if (valuesToSkip.Contains(value))
                    continue;
                // in this solution I had a method to get the description from the Enum
                // but you can avoid this part and populate your list with the enum values
                //enumList.Add(new KeyValuePair<Enum, string>(value, GetEnumDescription(value)));
                  enumList.Add(value);
            }
            return list;
        }
