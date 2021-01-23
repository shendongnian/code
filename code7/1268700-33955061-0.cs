      public class Menu
      {
        private static Menu instance = new Menu();
        public static Menu GetInstance()
        {
          return instance;
        }
        private List<Dish> menu = new List<Dish>();
        public void AddDish(Dish dish)
        {
          menu.Add(dish);
        }
    
        public static Menu Instance
        {
          get { return instance; }
        }
        public List<Dish> MenuList
        {
          get { return menu; }
          set { menu = value; }
        }
      }
