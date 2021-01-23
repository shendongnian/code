     public static class HtmlHelpers
     {
        public static HtmlString Hello(string Name)
        {
           return new HtmlString("Hello <b>" + Name + "</b>!");
        }
     }
