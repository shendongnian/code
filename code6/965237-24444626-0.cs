    using System.Collections.Generic;using System.Web.Mvc;
     
    namespace YourNameSpace.Domain.Utilities
    {
        public static class DropDownList<T>
        {
            public static SelectList LoadItems(IList<T> collection, string value, string text)
            {
                return new SelectList(collection, value, text);
            }
        }
     
    }
