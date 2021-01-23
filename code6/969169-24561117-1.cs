    class Base {}
    
    abstract class A<T> 
        where T : Base
    {
        abstract public List<T> Items { get; set; }
    }
    
    class Derived : Base {}
    
    class B : A<Derived>
    { 
        private List<Derived> items;
        public override List<Derived> Items
        {
               get
               {
                   return items;
               }
               set
               {
                items = value;
               }
          }
      }
