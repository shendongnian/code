    using Outlook = Microsoft.Office.Interop.Outlook;
    public static class ContactItemExtension
    {
        public static object Get(this Outlook.ContactItem item, string property)
        {
            object result = null;
            if (item == null) {
                // default null
                return result;
            }
            var ctype = item.GetType();
            var cprop = ctype.GetProperty(property);
            if (cprop == null || cprop.GetGetMethod() == null) {
                // no property found or it doesn't have a get
                return result;
            }
            result = cprop.GetValue(item, null);
            return result;
        }
    }
