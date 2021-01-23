    public class DayMenu
    {
        public string PortionTypeId { get; set; }
        public bool HasExtendedInfo { get; set; }
        public object MealPictureURL { get; set; }
        public string MenuAlternativeName { get; set; }
        public string DayMenuInfo { get; set; }
        public string DayMenuName { get; set; }
        public string MealId { get; set; }
        public bool ShowDayNutrient { get; set; }
        public bool ShowWeekNutrient { get; set; }
        public bool ShowIngredients { get; set; }
    }
    
    public class Day
    {
        public object InfoText { get; set; }
        public object DayMenuDate { get; set; }
        public List<DayMenu> DayMenus { get; set; }
    }
    
    public class Week
    {
        public string MenuId { get; set; }
        public string MenuName { get; set; }
        public int WeekNumber { get; set; }
        public List<Day> Days { get; set; }
    }
    
    public class RootObject
    {
        public List<Week> Weeks { get; set; }
        public string PortionTypeId { get; set; }
        public int CurrentWeek { get; set; }
        public object MenuPresInfoText { get; set; }
        public string MenuId { get; set; }
    }
