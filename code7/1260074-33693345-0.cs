    public class Parent {
       public Parent() {}
       public Parent(string s) {}
   }
    public class Child : Parents {
       public Child():base() // Call Parent empty constructor
       public Child(string s): base(s) // Call Parent Constructor with parameter
    }
