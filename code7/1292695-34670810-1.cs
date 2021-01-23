    public class Person
    {
       public string name;// this is global variable
       public Person(string name)
       {
         //now we have two variable with name 'name' and we have ambiguity. 
         //So when I will use this.name it will use the global variable.
         this.name = name; //will assign constructor name parameter to global name variable. 
        //If I will do name = name, it will use the local variable for assigning the value into 
         //local variable itself because local variable has high priority than global variable.
       }
    }
