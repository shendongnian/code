    using System;
    public abstract class MainClass { }
    public class Derived1 : MainClass { }
    public class Derived2 : MainClass { }
    
    class Program
    {
        static void Main(string[] args)
        {
            Array instances = Array.CreateInstance(typeof(MainClass), 5);
            instances.SetValue(AddItem(typeof(Derived1)), 0);
            instances.SetValue(AddItem(typeof(Derived2)), 1);
            instances.SetValue(AddItem(typeof(Derived1)), 2);
            instances.SetValue(AddItem(typeof(Derived2)), 3);
            instances.SetValue(AddItem(typeof(Derived1)), 4);
         }
        static MainClass AddItem<T>(T type) where T : Type
        {
            return (MainClass)Activator.CreateInstance(type);
        }
    }
