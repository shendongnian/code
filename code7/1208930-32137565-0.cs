    public static class AttributesExtensions
    {
        public static RouteValueDictionary AutofocusIf(
            this object htmlAttributes, 
            bool autofocus
        )
        {
            var attributes = new RouteValueDictionary(htmlAttributes);
            if (autofocus)
            {
                attributes["autofocus"] = "autofocus";
            }
            return attributes;
        }
    }
