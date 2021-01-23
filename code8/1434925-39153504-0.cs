    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Iterator
    {
      class Program
      {
        static void Main(string[] args)
        {
          MenuComponent pancakeHouseMenu = new Menu("PANCAKEHOUSE MENU", "Breakfast");
          MenuComponent dinerMenu = new Menu("DINER MENU", "Lunch");
          MenuComponent cafeMenu = new Menu("CAFE MENU", "Dinner");
          MenuComponent dessertMenu = new Menu("DESSERT MENU", "Dessert of course!");
    
          MenuComponent allMenus = new Menu("ALL MENUS", "All menus combined");
    
          allMenus.Add(pancakeHouseMenu);
          allMenus.Add(dinerMenu);
          allMenus.Add(cafeMenu);
    
          pancakeHouseMenu.Add(new MenuItem("K&B Pancake breakfast", "pancakes with scrambled eggs, and toast", true, 2.99));
          pancakeHouseMenu.Add(new MenuItem("Regular Pancake breakfast", "pancakes with fried eggs, sausage", false, 2.99));
    
          dinerMenu.Add(new MenuItem("Veggie burguer and air fries", "Veggie burguer on a whole wheat bun, lettuce, tomato and fries", true, 3.99));
          dinerMenu.Add(new MenuItem("Soup of the day", "Soup of the day with a side salad", false, 3.69));
    
          dinerMenu.Add(dessertMenu);
    
          dessertMenu.Add(new MenuItem("Apple pie", "Apple pie with a flakey crust, topped with vanilla ice cream", true, 1.59));
    
          cafeMenu.Add(new MenuItem("Vegetarian BLT", "(Fakin') Bacon with lettuce & tomato on whole wheat", true, 2.99));
          cafeMenu.Add(new MenuItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99));
    
          cafeMenu.Add(dessertMenu);
    
          Waitress waitress = new Waitress(allMenus);
          waitress.PrintVegetarianMenu();
        }
      }
    
      class Waitress
      {
        private MenuComponent AllMenus { get; set; }
    
        public Waitress(MenuComponent allMenus)
        {
          AllMenus = allMenus;
        }
    
        public void PrintMenu()
        {
          AllMenus.Print();
        }
    
        public void PrintVegetarianMenu()
        {
          Console.WriteLine("VEGATARIAN MENU");
    
          foreach (MenuComponent menuComponent in AllMenus)
          {
            try
            {
              if (menuComponent.Vegetarian)
              {
                menuComponent.Print();
                Console.Write("\n");
              }
            }
            catch (NotSupportedException)
            {
              Console.WriteLine("Operation not supported.");
            }
          }
        }
      }
    
      abstract class MenuComponent : IEnumerable<MenuComponent>
      {
        // Composite methods
        public abstract void Add(MenuComponent menuComponent);
    
        public abstract void Remove(MenuComponent menuComponent);
    
        public abstract MenuComponent GetChild(int i);
        // End of composite methods
    
        // Operation methods
        public virtual string Name { get; set; }
    
        public virtual string Description { get; set; }
    
        public virtual bool Vegetarian { get; set; }
    
        public virtual double Price { get; set; }
    
        public abstract void Print();
    
        public abstract IEnumerator<MenuComponent> GetEnumerator();
    
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      }
    
      /// This is a tree leaf
      class MenuItem : MenuComponent
      {
        public MenuItem(string name, string description, bool vegetarian, double price)
        {
          Name = name;
          Description = description;
          Vegetarian = vegetarian;
          Price = price;
        }
    
        public override void Print()
        {
          Console.Write("  " + Name);
          if (Vegetarian)
          {
            Console.Write("(v)");
          }
          Console.Write(", " + Price);
          Console.Write("     -- " + Description);
        }
    
        public override IEnumerator<MenuComponent> GetEnumerator()
        {
          yield break;
        }
    
        public override void Add(MenuComponent menuComponent)
        {
          throw new NotSupportedException();
        }
    
        public override void Remove(MenuComponent menuComponent)
        {
          throw new NotSupportedException();
        }
    
        public override MenuComponent GetChild(int i)
        {
          throw new NotSupportedException();
        }
      }
    
      /// This is a tree node
      class Menu : MenuComponent
      {
        private List<MenuComponent> MenuComponents;
    
        public Menu(string name, string description)
        {
          Name = name;
          Description = description;
          MenuComponents = new List<MenuComponent>();
        }
    
        public override void Add(MenuComponent menuComponent)
        {
          MenuComponents.Add(menuComponent);
        }
    
        public override void Remove(MenuComponent menuComponent)
        {
          MenuComponents.Remove(menuComponent);
        }
    
        public override MenuComponent GetChild(int i)
        {
          return MenuComponents[i];
        }
    
        // we have to use recursion to print all the hierarchy
        public override void Print()
        {
          Console.Write("\n" + Name);
          Console.WriteLine(", " + Description);
          Console.WriteLine("--------------");
    
          foreach (MenuComponent menuComponent in MenuComponents)
          {
            menuComponent.Print();
            Console.Write("\n");
          }
        }
    
        public override IEnumerator<MenuComponent> GetEnumerator()
        {
          var components = new Stack<MenuComponent>(new[] { this });
          while (components.Any())
          {
            MenuComponent component = components.Pop();
            yield return component;
            var menu = component as Menu;
            if (menu != null)
            {
              foreach (var n in menu.MenuComponents) components.Push(n);
            }
          }
        }
      }
    }
