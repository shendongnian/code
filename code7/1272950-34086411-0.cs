    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication2
    {
        using System;
        using System.Collections.Generic;
    
        public class ChildClass
        {
            private ParentClass parent;
    
            public ChildClass(ParentClass parentIn)
            {
                parent = parentIn;
            }
    
            public ParentClass Parent
            {
                get { return parent; }
            }
        }
       
        public class ParentClass
        {
            private List<ChildClass> children;
    
            public ParentClass()
            {
                children = new List<ChildClass>();
            }
    
            public ChildClass AddChild()
            {
                var newChild = new ChildClass(this);
                children.Add(newChild);
                return newChild;
            }
        }
    
    
        public class Program
        {
            public static void Main()
            {
                Console.WriteLine("Hello World");
    
                var p = new ParentClass();
                var firstChild = p.AddChild();
                var anotherChild = p.AddChild();
                var firstChildParent = firstChild.Parent;
                var anotherChildParent = anotherChild.Parent;
            }
        }
    }
