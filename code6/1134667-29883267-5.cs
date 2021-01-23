    public class Student{
       //rest of properties
       public Stack<int> Grades { get; private set; }
       
       public Student()
       {
           //rest of the code
           Grades = new Stack<int>();
       }
    }
