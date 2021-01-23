    public enum Color
    {
        Red,
        Green,
        Blue
    }
    public class User
    {
        public String Name { get; set; }
        public Color Color { get; set; }
    }
    public class UserColorAddEditViewModel
    {
        public String Name { get; set; }
        public Color Color { get; set; }
        public IList<SelectListItem> ColorSelectList { get; set; }
    }
