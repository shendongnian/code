    public class Animal
    {
       private string _name;
       public Animal(string name)
       {
         _name = name;
       }
       
       /*visible to children only empty ctor*/
       protected Animal() {}
    } 
    public class Dog : Animal
    {}
    
    void Main()
    {
    	var d = new Dog();
    }
