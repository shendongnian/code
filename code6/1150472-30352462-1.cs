        public static string AlertLevel(this XDocument decisionDocument, int size)
        {
            var queryResult = decisionDocument.Descendants("Decision");
            foreach (var item in queryResult)
            {
                var expAttribute = item.Attribute("Exp");
                if (expAttribute == null) continue;
                var returnString = CreateResultString(item);
                int minValue;
                int maxValue;
                if (expAttribute.Value.Contains(">") && expAttribute.Value.Contains("<="))
                {
                    //evaluate minValue < size > maxValue
                    var stringValue = expAttribute.Value.Replace("<=", string.Empty).Replace(">", string.Empty).Trim();
                    var stringValueArray = stringValue.Split('&');
                    if (int.TryParse(stringValueArray[1], out minValue) &&
                        int.TryParse(stringValueArray[0], out maxValue))
                    {
                        if (minValue < size &&
                            size < maxValue)
                            return returnString;
                    }
                }
                else if (expAttribute.Value.Contains(">"))
                {
                    //evaluate size > value
                    var stringValue = expAttribute.Value.Replace(">", string.Empty).Trim();
                    if (int.TryParse(stringValue, out maxValue))
                    {
                        if (size > maxValue)
                            return returnString;
                    }
                }
                else if (expAttribute.Value.Contains("<="))
                {
                    //else evaluate size < value
                    var stringValue = expAttribute.Value.Replace("<=", string.Empty).Trim();
                    if (int.TryParse(stringValue, out minValue))
                    {
                        if (size < minValue)
                            return returnString;
                    }
                }
            }
            return "No condition was met!";
        }
        private static string CreateResultString(XElement item)
        {
            var statusAttribute = item.Attribute("Status");
            var returnString = statusAttribute == null ? "Status" : statusAttribute.Value;
            var colorAttribute = item.Attribute("CellColor");
            returnString += colorAttribute == null ? "-Color" : "-" + colorAttribute.Value;
            return returnString;
        }
