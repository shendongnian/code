    public interface IView
    {
        string FirstName { get; }
        int Age { get; }
        string Name { get; }
    }
    public class Employee: IView
    {
         // make fields private if possible         
         private string firstName;
         private string lastname;
         private int age;
         private string workTitle;
         private string field1;
         private string field2;
         private string field3;
         // implements IView.FirstName as an auto property
         public string FirstName { get; set; }
         // implements IView.Age: returns the private age field
         public int Age { get { return age;} } 
         // explicit implementation of IView.Name: visible only as IView
         string IView.Name { get { return lastName + ", " + firstName; } }
    }
