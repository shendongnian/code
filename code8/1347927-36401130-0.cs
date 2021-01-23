     class Student {
       private int _ID; 
       public int ID {
         get {
           return _ID;
         }
         set {
           // input validation:
           // be exact, do not throw Exception but ArgumentOutOfRangeException:
           // it's argument that's wrong and it's wrong because it's out of range 
           if (value <= 0) 
             throw new ArgumentOutOfRangeException("value", "Id must be positive");
    
           _ID = value;
         }
       }
     }
...
    public static void Main()
    {
        Student C1 = new Student();
        C1.ID = 101;
        Console.WriteLine("Student ID = {0}", C1.ID);
    }
