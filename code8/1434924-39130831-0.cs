    class Program
    {
        static void Main(string[] args)
        {
            //var all = new Menu("ALL SECTIONS", "All menu sections");
            var pancakeHouseMenu = new Menu("PANCAKEHOUSE MENU", "Breakfast", 
                new MenuSection("PANCAKES", "Breakfast Pancakes Selection",
                    new MenuItem("K&B Pancake breakfast", "pancakes with scrambled eggs, and toast", true, 2.99m),
                    new MenuItem("Regular Pancake breakfast", "pancakes with fried eggs, sausage", false, 2.99m)));
            var dinnerMenu = new Menu("DINNER MENU", "Lunch",
                new MenuSection("","",
                    new MenuItem("Veggie burger and air fries", "Veggie burguer on a whole wheat bun, lettuce, tomato and fries", true, 3.99m),
                    new MenuItem("Soup of the day", "Soup of the day with a side salad", false, 3.69m)));
            var cafeMenu = new Menu("CAFE MENU", "Dinner",
                new MenuSection("", "",
                    new MenuItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99m),
                    new MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99m)),
                new MenuSection("DESSERT MENU", "Dessert of course!",
                    new MenuItem("Apple pie", "Apple pie with a flakey crust, topped with vanilla ice cream", true, 1.59m)));
            var waiter = new Waitress(pancakeHouseMenu, dinnerMenu, cafeMenu);
            //waiter.Print();
            //waiter.PrintVegenerian();
            WriteFileAndOpenNotepad(waiter.ToString());
            WriteFileAndOpenNotepad(waiter.ToVegetarianString());
        }
        static void WriteFileAndOpenNotepad(string text)
        {
            var fn = Path.GetTempFileName();
            fn=Path.ChangeExtension(fn, ".txt");
            File.WriteAllText(fn, text);
            Process.Start(fn);
        }
    }
    
    public abstract class MenuComponent
    {
        public string Description { get; private set; }
        public string Name { get; private set; }
        protected MenuComponent(string name, string description)
        {
            this.Name=name;
            this.Description=description;
        }
        public abstract override string ToString();
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string description, bool vegeterian, decimal price)
            : base(name, description)
        {
            this.Price=price;
            this.Vegetarian=vegeterian;
        }
        public decimal Price { get; set; }
        public bool Vegetarian { get; set; }
        public override string ToString()
        {
            //Use 28 columns for the item name
            return string.Format("{0,28}{1}, {2}     -- {3}",
                Name, Vegetarian ? "(v)" : "   ", Price, Description);
        }
    }
    public class MenuSection : MenuComponent
    {
        public MenuSection(string name, string description, params MenuItem[] items)
            : this(name, description, items as IEnumerable<MenuItem>)
        { }
        public MenuSection(string name, string description, IEnumerable<MenuItem> items) : base(name, description)
        {
            this.Items=new List<MenuItem>(items);
        }
        public List<MenuItem> Items { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            if(Name.Length>0)
            {
                sb.AppendFormat("{0}, {1}", Name, Description);
                sb.AppendLine();
                sb.AppendLine("--------------");
            }
            foreach(var item in Items)
            {
                sb.AppendLine();
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public MenuSection VegeterianSections
        {
            get
            {
                var veg = Items.Where((item) => item.Vegetarian);
                return new MenuSection(Name, Description, veg);
            }
        }
    }
    public class Menu : MenuComponent
    {
        public Menu(string name, string description, IEnumerable<MenuSection> sections)
            : base(name, description)
        {
            this.MenuSections=new List<MenuSection>(sections);
        }
        public Menu(string name, string description, params MenuSection[] sections)
            : this(name, description, sections as IEnumerable<MenuSection>)
        { }
        public List<MenuSection> MenuSections { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendFormat("[{0}, {1}]", Name, Description);
            sb.AppendLine();
            sb.AppendLine("==============");
            foreach(var section in MenuSections)
            {
                sb.AppendLine();
                sb.AppendLine(section.ToString());
            }
            return sb.ToString();
        }
        public Menu VegeraterianMenu
        {
            get
            {
                return new Menu(Name, Description, MenuSections.Select((section)=> section.VegeterianSections));
            }
        }
    }
    public class Waitress
    {
        public Waitress(params Menu[] all)
        {
            this.AllMenus=new List<Menu>(all);
            this.VegeratianMenu=all.Select((menu)=>menu.VegeraterianMenu).ToList();
        }
        public IList<Menu> AllMenus { get; private set; }
        public IList<Menu> VegeratianMenu { get; private set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** A L L  I T E M S ***");
            foreach(var item in AllMenus)
            {
                sb.AppendLine("************************");
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public string ToVegetarianString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** V E G  I T E M S ***");
            foreach(var item in VegeratianMenu)
            {
                sb.AppendLine("************************");
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public void PrintVegenerian()
        {
            Console.WriteLine(ToVegetarianString());
        }
    }
